﻿using SQLite;

namespace MyPatchV3.BL.Contracts
{
    public abstract class EntityBase : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
