﻿using System;
using System.Collections.Generic;

namespace Shared.Domain
{
    public class Template
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();
    }
}