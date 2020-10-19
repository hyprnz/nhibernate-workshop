using CmdLine.DataAccess;
using NHibernate;
using Shared.Domain;
using System;

namespace Shared.DataAccess
{
    public class SessionAccessor : ISessionAccessor
    {
        public T Get<T>(Guid id) where T : DomainObject
        {
            return Session.Get<T>(id);
        }

        public Guid Save(DomainObject obj)
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
