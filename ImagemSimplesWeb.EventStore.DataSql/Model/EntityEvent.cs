using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.EventStore.DataSql.Model
{
    public class EntityEvent : BasicInfo
    {
        public EntityEvent(string entityName, string action, string id, byte[] entity, string codigoUsuario, string hostName, string userNameComputer, string ip, string app)
        {
            Id = Guid.NewGuid();
            EntityName = entityName;
            Action = action;
            EntityId = id;
            Entity = entity;
            TimeStamp = DateTime.Now;
            CodigoUsuario = codigoUsuario;
            HostName = hostName;
            UserNameComputer = userNameComputer;
            Ip = ip;
            App = app;
        }

        public EntityEvent(string entityName, string action, Guid? id, byte[] entity, string codigoUsuario, string hostName, string userNameComputer, string ip, string app)
        {
            Id = Guid.NewGuid();
            EntityName = entityName;
            Action = action;
            EntityIdGuid = id;
            Entity = entity;
            TimeStamp = DateTime.Now;
            CodigoUsuario = codigoUsuario;
            HostName = hostName;
            UserNameComputer = userNameComputer;
            Ip = ip;
            App = app;
        }

        public Guid Id { get; set; }
        public string EntityName { get; set; }
        public string Action { get; set; }
        public Guid? EntityIdGuid { get; set; }
        public string EntityId { get; set; }
        public byte[] Entity { get; set; }
     


    }
}
