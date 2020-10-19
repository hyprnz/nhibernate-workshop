using NHibernate;
using System;

namespace CmdLine.DataAccess
{
    public interface ISessionAccessor
    {
        /// <summary>
        /// Strongly-typed version of NHibernate.ISession.Get(System.Type,System.Guid)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get<T>(Guid id);

        /// <summary>
        /// Persist the given transient instance, first assigning a generated identifier.
        /// </summary>
        /// <param name="obj">A transient instance of a persistent class</param>
        /// <returns>The generated identifier</returns>
        /// <remarks>Save will use the current value of the identifier property if the Assigned generator 
        /// is used.</remarks>
        Guid Save(object obj);

        ISession Session { get; }
    }
}
