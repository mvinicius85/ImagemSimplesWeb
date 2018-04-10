using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.EventStore.DataSql.Model
{
    public  class AccessEvent : BasicInfo
    {
        public AccessEvent(string form, string tipoAcesso, string codigoUsuario, string hostName, string userNameComputer, string ip,string app)
        {
            Id = Guid.NewGuid();
            Form = form;
            TipoAcesso = tipoAcesso;
            CodigoUsuario = codigoUsuario;
            HostName = hostName;
            UserNameComputer = userNameComputer;
            Ip = ip;
            App = app;
        }

        public Guid Id { get; set; }
        
        public string Form { get; set; }
        public string TipoAcesso { get; set; }


    }
}
