using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ImagemSimplesWeb.Core.Infra.Data.Contexto
{
    public class ArquivoMdbContext : DbContext
    {
        static ArquivoMdbContext()
        {
            Database.SetInitializer<ArquivoMdbContext>(null);
        }

        public ArquivoMdbContext()
            : base("Data Source=OM30NBRH98KVVC\\SQLEXPRESS;Initial Catalog=Imagem_Itapevi;Persist Security Info=True;User ID=sa; Password=password123;MultipleActiveResultSets=True;App=ImagemSimplesWeb")
        {
        }
    }

}
