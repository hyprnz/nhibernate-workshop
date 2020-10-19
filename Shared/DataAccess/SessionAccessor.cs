using CmdLine.DataAccess;
using NHibernate;
using System;

namespace Shared.DataAccess
{
    public class SessionAccessor : ISessionAccessor
    {
        public T Get<T>(Guid id)
        {
            return Session.Get<T>(id);
        }

        public Guid Save(object obj)
        {
            return (Guid)Session.Save(obj);
        }

        public ISession Session {
            get {
                return TransactionAspect.AsyncLocalSession.Value;
            }
        }
    }
}
