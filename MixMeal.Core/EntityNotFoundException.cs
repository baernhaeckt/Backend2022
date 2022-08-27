﻿using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace MixMeal.Core;

/// <summary>
///     Exception thrown when a entity was not found.
/// </summary>
[Serializable]
public abstract class EntityNotFoundException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
    /// </summary>
    protected EntityNotFoundException()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
    /// </summary>
    /// <param name="entityName">The name of the entity for which the lookup returned no result.</param>
    /// <param name="primaryKey">The primary key which was used to look for an entity.</param>
    protected EntityNotFoundException(string entityName, object primaryKey)
        : base($"An entity lookup for \"{entityName}\" with the primary key \"{primaryKey}\" returned no result.")
    {
        EntityName = entityName;
        PrimaryKey = primaryKey;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
    /// </summary>
    /// <param name="entityName">The name of the entity for which the lookup returned no result.</param>
    /// <param name="searchExpression">The search expression which was used to look for an entity.</param>
    protected EntityNotFoundException(string entityName, Expression searchExpression)
        : base($"An entity lookup for \"{entityName}\" with the search expression \"{searchExpression}\" returned no result.")
    {
        EntityName = entityName;
        SearchExpression = searchExpression;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
    /// </summary>
    protected EntityNotFoundException(string? message)
        : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
    /// </summary>
    protected EntityNotFoundException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
    /// </summary>
    protected EntityNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    /// <summary>
    ///     Gets the Id by which the entity was searched, if any.
    /// </summary>
    public object? PrimaryKey { get; }

    /// <summary>
    ///     Gets the search expression by which the entity was searched, if any.
    /// </summary>
    public Expression? SearchExpression { get; }

    /// <summary>
    ///     Gets the name of the entity type.
    /// </summary>
    public string? EntityName { get; }
}

/// <inheritdoc />
[Serializable]
public class EntityNotFoundException<TEntity> : EntityNotFoundException
{
    /// <inheritdoc cref="EntityNotFoundException()" />
    public EntityNotFoundException()
    {
    }

    /// <inheritdoc cref="EntityNotFoundException(string, object)" />
    public EntityNotFoundException(object primaryKey)
        : base(typeof(TEntity).Name, primaryKey)
    {
    }

    /// <inheritdoc cref="EntityNotFoundException(string, Expression)" />
    public EntityNotFoundException(Expression searchExpression)
        : base(typeof(TEntity).Name, searchExpression)
    {
    }

    /// <inheritdoc cref="EntityNotFoundException(string?)" />
    public EntityNotFoundException(string? message)
        : base(message)
    {
    }

    /// <inheritdoc cref="EntityNotFoundException(string?, Exception?)" />
    public EntityNotFoundException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    /// <inheritdoc cref="EntityNotFoundException(SerializationInfo, StreamingContext)" />
    protected EntityNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}