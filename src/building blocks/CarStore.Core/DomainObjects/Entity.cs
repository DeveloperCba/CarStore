using CarStore.Core.Messages;
using FluentValidation;

namespace CarStore.Core.DomainObjects;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    private List<Event> _notifications;
    public IReadOnlyCollection<Event> Notifications => _notifications?.AsReadOnly();

    public void AddEvent(Event @event)
    {
        _notifications = _notifications ?? new List<Event>();
        _notifications.Add(@event);
    }

    public void RemoveEvent(Event eventItem)
    {
        _notifications?.Remove(eventItem);
    }

    public void ClearEvent()
    {
        _notifications?.Clear();
    }

    protected bool ExecuteValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true;

        return false;
    }

    public virtual bool IsValid()
    {
        throw new NotImplementedException();
    }

    #region Comparações
    public override bool Equals(object obj)
    {
        var compareTo = obj as Entity;

        if (ReferenceEquals(this, compareTo)) return true;
        if (ReferenceEquals(null, compareTo)) return false;

        return Id.Equals(compareTo.Id);
    }
    public static bool operator ==(Entity a, Entity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }
    public static bool operator !=(Entity a, Entity b) => !(a == b);

    public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

    public override string ToString() => $"{GetType().Name} [Id={Id}]";

    #endregion
}
