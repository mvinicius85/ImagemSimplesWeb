using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.EventStore.DataSql.Model
{
   public class ExceptionEvent : BasicInfo
    {
        public ExceptionEvent( string app, string codigoUsuario, string hostName, string userNameComputer, string ip, string exceptionType, string method, string StackTrace, string exception)
        {
            Id = Guid.NewGuid();
            App = app;        
            
            CodigoUsuario = codigoUsuario;
            HostName = hostName;
            UserNameComputer = userNameComputer;
            Ip = ip;
            ExceptionType = exceptionType;
            Method = method;
            this.StackTrace = StackTrace;
            Exception = exception;
            TimeStamp = DateTime.Now;
        }

        public Guid Id { get; set; }
      
        public string ExceptionType { get; set; }
        public string Method { get; set; }
        public string StackTrace { get; set; }
        public string Exception { get; set; }
      

    }
}
