using CmdLine.Repositories;
using NHibernate;
using System;
using System.Diagnostics;

namespace CmdLine.DataAccess
{

    public interface ISessionAccessor
    {
        //
        // Summary:
        //     Strongly-typed version of NHibernate.ISession.Get(System.Type,System.Object)
        T Get<T>(Guid id);

        //
        // Summary:
        //     Persist the given transient instance, first assigning a generated identifier.
        //
        // Parameters:
        //   obj:
        //     A transient instance of a persistent class
        //
        // Returns:
        //     The generated identifier
        //
        // Remarks:
        //     Save will use the current value of the identifier property if the Assigned generator
        //     is used.
        Guid Save(object obj);

        ISession Session { get; }
    }
}
