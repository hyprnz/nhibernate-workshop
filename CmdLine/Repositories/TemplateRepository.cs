using Autofac.Extras.DynamicProxy;
using CmdLine.DataAccess;
using CmdLine.Domain;
using NHibernate;
using System;

namespace CmdLine.Repositories
{
    [Intercept(typeof(TransactionInterceptor))]
    public class TemplateRepository : ITemplateRepository
    {
        public Guid Save(Template template)
        {
            return (Guid)Session.Save(template);
        }

        public ISession Session { get; set; }

        public Template GetById(Guid id)
        {
            return Session.Get<Template>(id);
            //Template template = null;
            //using (var session = SessionFactory.OpenSession())
            //{
            //    using (var txn = session.BeginTransaction())
            //    {
            //        try
            //        {
            //            template = Session.Get<Template>(id);
            //            txn.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            txn.Rollback();
            //            throw;
            //        }
            //    }
            //    session.Close();
            //}
            //return template;
        }
    }
}
