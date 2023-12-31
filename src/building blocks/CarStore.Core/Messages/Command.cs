﻿using CarStore.Core.DomainObjects;
using FluentValidation.Results;
using MediatR;

namespace CarStore.Core.Messages;

public abstract class Command : Message, IRequest<ValidationResult> 
{

    public DateTime Timestamp { get; private set; }
    public ValidationResult ValidationResult { get; set; } = null!;

    protected Command()
    {
        Timestamp = DateTime.Now;
    }

    public virtual bool EhValido()
    {
        throw new NotImplementedException();
    }
 
}