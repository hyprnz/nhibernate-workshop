﻿using CmdLine.DataAccess;
using CmdLine.Domain;
using System;

namespace CmdLine.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        public TemplateRepository(ISessionAccessor sessionAccessor)
        {
            SessionAccessor = sessionAccessor;
        }

        public Guid Save(Template template)
        {
            return SessionAccessor.Save(template);
        }

        private ISessionAccessor SessionAccessor { get; }

        public Template GetById(Guid id)
        {
            return SessionAccessor.Get<Template>(id);
        }
    }
}
