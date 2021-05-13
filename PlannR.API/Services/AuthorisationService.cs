using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using PlannR.Application.Contracts.Identity;
using PlannR.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace PlannR.API.Services
{
    public class AuthorisationService<T> : IAuthorisationService<T>
        where T : AuditableEntity
    {
        private readonly string _userId;

        public AuthorisationService(IHttpContextAccessor accessor)
        {
            _userId = accessor.HttpContext?.User?.Identity?.Name;
        }

        public bool CanAccessEntity(T entity)
        {
            if (string.IsNullOrWhiteSpace(entity.CreatedBy) && string.IsNullOrWhiteSpace(_userId)) return true;

            return _userId == entity.CreatedBy;
        }

        public ICollection<T> RemoveInAccessibleEntities(ICollection<T> entities)
        {
            var toRemove = new List<T>();

            for(int i = 0; i < entities.Count; i++)
            {
                var entity = entities.ElementAt(i);
                if (!CanAccessEntity(entities.ElementAt(i))) entities.Remove(entity);
            }
            return entities;
        }
    }
}
