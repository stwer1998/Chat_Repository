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
        //string groupname = "cats";
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
            if (message != null)
            {
                await Clients.Group(groupname).SendAsync("Receive", message, username);
            }
            else await Clients.Caller.SendAsync("Receive","Вы заблокированны",username);
        }

        private string Command(string message,string login,string id)
        {
            IGroupRepository db = new GroupRepository();
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
                                                 
                        case "//add user": db.AddMember(groupId, db.GetUser(login), db.GetUser(param)); return login + " добавил :" + param;
                        case "//ban user": db.DropMember(groupId, db.GetUser(login), db.GetUser(param)); return login + " удалил :" + param;
                        case "//block user": db.BlockUser(groupId, db.GetUser(login), db.GetUser(param)); return login + " заблокировал :" + param;
                        case "//activate user": db.UnlockUser(groupId, db.GetUser(login), db.GetUser(param)); return login + " разблокировал :" + param;
                        case "//add moderator": db.AddModerator(groupId, db.GetUser(login), db.GetUser(param)); return login + " сделал модератором :" + param;
                        case "//ban moderator": db.DropModerator(groupId, db.GetUser(login), db.GetUser(param)); return login + " удалил модератора :" + param;
                        case "//room rename": db.RenameGroup(groupId, db.GetUser(login), param); return login + " переименовал комнату :" + param;
                    }
                }
            }
            if (db.Check(db.GetUser(login),groupId)!= "blocked") { return message; }
            else return null;                
                
        }
        
    }
}
