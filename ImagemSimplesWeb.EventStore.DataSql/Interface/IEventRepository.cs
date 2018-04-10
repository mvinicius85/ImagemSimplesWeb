
using ImagemSimplesWeb.EventStore.DataSql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.EventStore.DataSql.Interface
{
    public interface IEventRepository
    {

      void   Store(EntityEvent eventToLog);
        void Store(ExceptionEvent eventExp);
        void Store(AccessEvent eventAcesso);

        IList<EntityEvent> AllEvent(Guid aggregateId);

        IList<EntityEvent> AllEvent(string aggregateId);
    }
}
