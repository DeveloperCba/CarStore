﻿using FluentValidation.Results;

namespace CarStore.Core.DomainObjects.Exceptions;

public class ValidationException : ApplicationException
{
    public ValidationException() : base("Existem erros de validações.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

    }


    public IDictionary<string, string[]> Errors { get; }
}