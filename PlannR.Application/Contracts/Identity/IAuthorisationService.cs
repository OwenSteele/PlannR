using PlannR.Domain.Common;
using System.Collections.Generic;

namespace PlannR.Application.Contracts.Identity
{
    public interface IAuthorisationService<T> where T : AuditableEntity
    {
        bool CanAccessEntity(T entity);
        ICollection<T> RemoveInAccessibleEntities(ICollection<T> entities);
    }
}
