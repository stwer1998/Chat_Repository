using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModels
{
    public interface IGroupRepository
    {
        /// <summary>
        /// Создаёт новую группу с названием
        /// </summary>
        /// <param name="user">Основатель группы</param>
        /// <param name="name">Название группы</param>
        /// <returns></returns>
        int GreateGroup(User user,string name);
        /// <summary>
        /// Добавляет в группу нового пользователя
        /// </summary>
        /// <param name="groupId">Идентификатор группы</param>
        /// <param name="user">Кто требует добавление</param>
        /// <param name="newuser">Кого нужно добавить</param>
        void AddMember(int groupId, User user, User newuser);
        /// <summary>
        /// Блокирует участника группы
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="user"></param>
        /// <param name="blockinguser"></param>
        void BlockUser(int groupId, User user, User blockuser);
        /// <summary>
        /// Разблокирует участника группы
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="user"></param>
        /// <param name="unlockkuser"></param>
        void UnlockUser(int groupId, User user, User unlockkuser);
        /// <summary>
        /// Удалит из группы участника
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="user"></param>
        /// <param name="dropuser"></param>
        void DropMember(int groupId, User user, User dropuser);
        /// <summary>
        /// Добавит модератор в группу
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="user"></param>
        /// <param name="moderatoruser"></param>
        void AddModerator(int groupId, User user, User moderatoruser);
        /// <summary>
        /// Удалит модератора из группы
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="user"></param>
        /// <param name="dropmoderator"></param>
        void DropModerator(int groupId, User user, User dropmoderator);
        /// <summary>
        /// Переименует группу
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="user"></param>
        /// <param name="newname"></param>
        void RenameGroup(int groupId, User user,string newname);
        /// <summary>
        /// Отправка сообщений
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="senduser"></param>
        /// <param name="message"></param>
        void SendMessage(int groupId, User senduser, string message);
        /// <summary>
        /// Удаление сообщений
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="user"></param>
        /// <param name="idmessage"></param>
        void DeleteMessage(int groupId, User user, int idmessage);
        /// <summary>
        /// Получение список груп полтзователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Group> GetUserGroups(User user);

    }
}
