using PlannR.Domain.Common;
using System.Collections.Generic;

namespace PlannR.Application.Contracts.Identity
{
    public interface IAuthorisationService<T> where T : AuditableEntity
    {
        bool CanAccessEntity(T entity);
        bool CanAccessEntity(T entity, bool includeAnonymous);
        ICollection<T> RemoveInAccessibleEntities(ICollection<T> entities);
        ICollection<T> RemoveInAccessibleEntities(ICollection<T> entities, bool includeAnonymous);
        bool CanCreateEntity();
        bool CanAlterEntity(T entity);
    }
}
