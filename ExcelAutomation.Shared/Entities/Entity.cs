﻿namespace ExcelAutomation.Shared.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
