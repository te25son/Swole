﻿using System;

namespace Swole.Data
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set; }
    }
}
