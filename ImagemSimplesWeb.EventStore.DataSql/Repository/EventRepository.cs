using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;
using System.Data.Entity;
using ImagemSimplesWeb.EventStore.DataSql.Interface;
using ImagemSimplesWeb.EventStore.DataSql.Model;

namespace ImagemSimplesWeb.EventStore.DataSql.Repository
{
    public class EventRepository: IEventRepository
    {

        private readonly Contexto.EventContext _db;
        private readonly IDbConnection _con;




        public EventRepository(Contexto.EventContext context)
        {
            _db = context;

            _con = _db.Database.Connection;

        }

        //public EventRepository()
        //{
        //    _db = new Contexto.EventContext();

        //    _con = _db.Database.Connection;
        //}
        public void Store(EntityEvent eventToLog)
        {

            try
            {

              


                    eventToLog.TimeStamp = DateTime.Now;
                    _con.Open();
                    var sql = @"insert EntityEvent values (@Id, @EntityName,@Action,@EntityIdGuid,@EntityId,@Entity,@App,@CodigoUsuario,@HostName,@UserNameComputer,@Ip,@TimeStamp)";
                    _con.Execute(sql, eventToLog);

                
            }
            finally
            {

                _con.Close();
            }

            //_db.EntityEvents.Add(eventToLog);
            //_db.SaveChanges();
        }

        public void Store(ExceptionEvent eventExp)
        {
            eventExp.TimeStamp = DateTime.Now;
            _db.ExceptionEvent.Add(eventExp);
            _db.SaveChanges();
        }

        public void Store(AccessEvent eventAcesso) 
        {
            eventAcesso.TimeStamp = DateTime.Now;
            _db.AccessEvent.Add(eventAcesso);
            _db.SaveChanges();
        }


        public IList<EntityEvent> AllEvent(Guid aggregateId)
        {
            var events = (from e in _db.EntityEvents where e.EntityIdGuid == aggregateId select e).ToList();
            return events;
        }

        public IList<EntityEvent> AllEvent(string aggregateId)
        {
            var events = (from e in _db.EntityEvents where e.EntityId == aggregateId select e).ToList();
            return events;
        }



    }
}
