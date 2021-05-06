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

        public AuthorisationService(IHttpContextAccessor accessor)
        {
            _userId = accessor.HttpContext?.User?.Identity?.Name;
        }

        public bool CanAccessEntity(T entity)
        {
            if (string.IsNullOrWhiteSpace(entity.CreatedBy)) return true;

            return _userId == entity.CreatedBy;
        }

        public ICollection<T> RemoveInAccessibleEntities(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                if (!CanAccessEntity(entity)) entities.Remove(entity);
            }
            return entities;
        }
    }
}
