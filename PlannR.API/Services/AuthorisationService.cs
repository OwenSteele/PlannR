using Microsoft.AspNetCore.Http;
using PlannR.Application.Contracts.Identity;
using PlannR.Domain.Common;
using System.Collections.Generic;

namespace PlannR.API.Services
{
    public class AuthorisationService<T> : IAuthorisationService<T>
        where T : AuditableEntity
    {
        private readonly string _userId;

        public AuthorisationService(
            IHttpContextAccessor accessor)
        {
            _userId = accessor.HttpContext?.User?.Identity?.Name;

        }

        public bool CanAccessEntity(T entity, bool includeAnonymous = false)
        {
            if (string.IsNullOrWhiteSpace(entity?.CreatedBy) && 
                (string.IsNullOrWhiteSpace(_userId) || includeAnonymous)) return true;

            return _userId == entity?.CreatedBy;
        }

        public bool CanCreateEntity() => !string.IsNullOrWhiteSpace(_userId);

        public ICollection<T> RemoveInAccessibleEntities(ICollection<T> entities, bool includeAnonymous = false)
        {
            var toRemove = new List<T>();

            foreach (var entity in entities)
            {
                if (!CanAccessEntity(entity, includeAnonymous)) toRemove.Add(entity);
            }

            foreach (var r in toRemove)
            {
                entities.Remove(r);
            }
            return entities;
        }
    }
}
