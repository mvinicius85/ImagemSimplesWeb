using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.EventStore.DataSql.Model
{
   public abstract class BasicInfo
    {
        public string App { get; set; }
        public string CodigoUsuario { get; set; }
        public string HostName { get; set; }
        public string UserNameComputer { get; set; }
        public string Ip { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
