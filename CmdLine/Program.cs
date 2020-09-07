using CmdLine.DataAccess;
using CmdLine.Domain;
using System;

namespace CmdLine
{
    static class Program
    {
        static void Main(string[] args)
        {
            Database.RunMigrations();

            // From here the database schema is in the desired state and we can start using the database
         
            var sessionFactory = Database.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var log = new Log { Text = $"Hello, world! {DateTime.UtcNow}" };
                    session.Save(log);
                    txn.Commit();
                }

                using (var txn = sessionFactory.OpenSession())
                {
                    foreach (var log in session.Query<Log>())
                    {
                        Console.WriteLine($"{log.Id}: {log.Text}");
                    }
                }
            }
        }
    }
}
