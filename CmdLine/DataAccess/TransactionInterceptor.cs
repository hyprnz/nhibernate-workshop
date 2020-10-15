using CmdLine.Repositories;
using NHibernate;
using System;

namespace CmdLine.DataAccess
{
    public class TransactionInterceptor : Castle.DynamicProxy.IInterceptor
    {
        public TransactionInterceptor(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        public void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    try
                    {
                        var target = invocation.InvocationTarget as INeedSession;
                        target.Session = session;
                        invocation.Proceed();
                        target.Session = null;
                        txn.Commit();
                    }
                    catch (Exception ex)
                    {
                        txn.Rollback();
                        throw;
                        // TODO: retry logic subject to error code
                    }
                }
                session.Close();
            }
        }

        private NHibernate.ISessionFactory SessionFactory { get; }
    }
}
