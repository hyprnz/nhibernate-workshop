using CmdLine.Repositories;
using NHibernate;
using System;
using System.Diagnostics;

namespace CmdLine.DataAccess
{

    public class SessionAccessor : ISessionAccessor
    {
        public T Get<T>(Guid id)
        {
            return Session.Get<T>(id);
        }

        public Guid Save(object obj)
        {
            return (Guid) Session.Save(obj);
        }

        public ISession Session {
            get {
                return TransactionInterceptor.AsyncLocalSession.Value;
            }
        }
    }
}
