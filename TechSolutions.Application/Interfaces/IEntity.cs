﻿namespace TechSolutions.Application.Interfaces
{
    public interface IEntity
    {
        long Oid { get; set; }
    }

    public interface IIdentityEntity
    {
        long Id { get; set; }
    }
}
