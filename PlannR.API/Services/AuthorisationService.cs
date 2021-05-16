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
            // Identity is but name is null with correct claims
            _userId = accessor.HttpContext?.User?.Identity?.Name;

        }

        public bool CanAccessEntity(T entity)
        {
            if (string.IsNullOrWhiteSpace(entity?.CreatedBy) && string.IsNullOrWhiteSpace(_userId)) return true;

            return _userId == entity?.CreatedBy;
        }

        public ICollection<T> RemoveInAccessibleEntities(ICollection<T> entities)
        {
            var toRemove = new List<T>();

            foreach (var entity in entities)
            {
                if (!CanAccessEntity(entity)) toRemove.Add(entity);
            }

            foreach (var r in toRemove)
            {
                entities.Remove(r);
            }
            return entities;
        }
    }
}
