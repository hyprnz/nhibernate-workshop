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
                        AsyncLocalSession.Value = session;
                        try
                        {
                            invocation.Proceed();
                            txn.Commit();
                        }
                        finally
                        {
                            AsyncLocalSession.Value = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        txn.Rollback();
                        throw;
                        // TODO: retry depending on error code
                    }
                }
                session.Close();
            }
        }

        internal static System.Threading.AsyncLocal<ISession> AsyncLocalSession = new System.Threading.AsyncLocal<ISession>();
        // Details about AsyncLocal<T> at https://docs.microsoft.com/en-us/dotnet/api/system.threading.asynclocal-1 [Manfred]

        private NHibernate.ISessionFactory SessionFactory { get; }
    }
}
