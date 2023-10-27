using CarStore.Core.Messages;
using FluentValidation;

namespace CarStore.Core.DomainObjects;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    

    private List<Event>? _notifications;

    public IReadOnlyCollection<Event>? GetNotifications() => _notifications?.AsReadOnly();

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
    public void AddEvent(Event @event)
    {
        _notifications ??= new List<Event>();
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

    public virtual bool IsValid()
    {
        throw new NotImplementedException();
    }

    #region Comparações
    public override bool Equals(object? obj)
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
