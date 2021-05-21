using Moq;
using PlannR.Application.Contracts.Identity;
using PlannR.Domain.Common;
using System.Collections.Generic;

namespace PlannR.Application.Tests
{
    public class HandlerTestsBase<T> where T : AuditableEntity
    {
        protected readonly Mock<IAuthorisationService<T>> _mockAuthorisationService;

        public HandlerTestsBase()
        {
            _mockAuthorisationService = new Mock<IAuthorisationService<T>>();
            _mockAuthorisationService.Setup(x => x.CanAccessEntity(It.IsAny<T>())).Returns(true);
            _mockAuthorisationService.Setup(x => x.RemoveInAccessibleEntities(It.IsAny<ICollection<T>>())).Returns(
                (ICollection<T> collection) =>
                {
                    return collection;
                });
        }
    }
}
