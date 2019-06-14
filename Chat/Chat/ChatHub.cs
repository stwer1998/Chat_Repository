using ChatModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat
{
    public class ChatHub : Hub
    {
        private IGroupRepository db;
        public ChatHub(IGroupRepository _db)
        {
            db = _db;
        }
        

        public async Task Enter(string username,string groupname)
        {
            if (String.IsNullOrEmpty(username))
            {
                await Clients.Caller.SendAsync("Notify", "Для входа в чат введите логин");
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
                await Clients.Group(groupname).SendAsync("Notify", $"{username} вошел в чат");
            }
        }
        public async Task Send(string message, string username, string groupname)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
            message = Command(message,username,groupname);
            if (message != null && message != "У вас нет прав на это")
            {
                await Clients.Group(groupname).SendAsync("Receive", message, username);
            }
            else if (message== "У вас нет прав на это") {await Clients.Caller.SendAsync("Receive", "У вас нет прав на это", username); }
            else await Clients.Caller.SendAsync("Receive", "Вы заблокированны", username);
        }

        private string Command(string message,string login,string id)
        {
            int groupId = Convert.ToInt32(id);
            if (message.StartsWith("//"))
            {
                var array = message.Split(' ');
                if (array[0] == "//help")
                {
                    return "//help все команды " +
                      "//add user {username} добавит в группу пользоваткля " +
                      "//ban user {username} " +
                      "//block user {username} " +
                      "//activate user {username} " +
                      "//add moderator {username} " +
                      "//ban moderator {username} " +
                      "//room rename {newname} ";
                }
                else
                {
                    string command = array[0]+" " + array[1];
                    string param = array[2];
                    switch (command)
                    {
                                                 
                        case "//add user": return db.AddMember(groupId, db.GetUser(login), db.GetUser(param)); 
                        case "//ban user": return db.DropMember(groupId, db.GetUser(login), db.GetUser(param)); 
                        case "//block user":return db.BlockUser(groupId, db.GetUser(login), db.GetUser(param)); 
                        case "//activate user":return db.UnlockUser(groupId, db.GetUser(login), db.GetUser(param)); 
                        case "//add moderator":return db.AddModerator(groupId, db.GetUser(login), db.GetUser(param)); 
                        case "//ban moderator":return db.DropModerator(groupId, db.GetUser(login), db.GetUser(param)); 
                        case "//room rename":return db.RenameGroup(groupId, db.GetUser(login), param); 
                    }
                }
            }
            if (db.Check(db.GetUser(login),groupId)!= "blocked") { return message; }
            else return null;                
                
        }
        
    }
}
