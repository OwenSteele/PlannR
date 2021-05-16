using Microsoft.AspNetCore.Http;
using Moq;
using PlannR.API.Services;
using PlannR.Domain.Common;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PlannR.API.Tests.Services
{
    public class AuthorisationServiceTests
    {
        private readonly Mock<IHttpContextAccessor> _accessor;

        public AuthorisationServiceTests()
        {
            _accessor = new Mock<IHttpContextAccessor>();

        }

        [Fact]
        public void WHEN_Entity_with_matching_userId_is_passed_in_THEN_true_returned_as_authorised()
        {
            var userName = "UserOne";
            var entity = new AuditableEntity
            {
                CreatedBy = userName
            };

            _accessor.Setup(x => x.HttpContext.User.Identity.Name)
                .Returns(userName);
            var service = new AuthorisationService<AuditableEntity>(_accessor.Object);

            var result = service.CanAccessEntity(entity);

            result.ShouldBe(true);
        }

        [InlineData("")]
        [InlineData("UserTwo")]
        [Theory]
        public void WHEN_Entity_has_no_createdBy_value_THEN_entity_is_always_returned(string userName)
        {
            var entity = new AuditableEntity
            {
                CreatedBy = string.Empty
            };

            _accessor.Setup(x => x.HttpContext.User.Identity.Name)
                .Returns(userName);
            var service = new AuthorisationService<AuditableEntity>(_accessor.Object);

            var result = service.CanAccessEntity(entity);

            result.ShouldBe(true);
        }
        [Fact]
        public void WHEN_Entity_has_different_userId__THEN_false_is_returned_as_unauthorised()
        {
            var entity = new AuditableEntity
            {
                CreatedBy = "UserThree"
            };

            _accessor.Setup(x => x.HttpContext.User.Identity.Name)
                .Returns("NoMatch");
            var service = new AuthorisationService<AuditableEntity>(_accessor.Object);

            var result = service.CanAccessEntity(entity);

            result.ShouldBe(false);
        }

        [InlineData("", 1)]
        [InlineData("UserFour", 3)]
        [InlineData("UserFive", 2)]
        [Theory]
        public void WHEN_Entities_have_partial_matching_userIds_THEN_only_matching_entities_are_returned(
            string userName, int expectedResults)
        {

            var collection = new List<AuditableEntity> {
                new AuditableEntity
                {
                    CreatedBy = string.Empty
                },
                new AuditableEntity
                {
                    CreatedBy = "UserFour"
                },
                new AuditableEntity
                {
                    CreatedBy = "UserFour"
                },
                new AuditableEntity
                {
                    CreatedBy = "UserFive"
                }
            };

            _accessor.Setup(x => x.HttpContext.User.Identity.Name)
                .Returns(userName);
            var service = new AuthorisationService<AuditableEntity>(_accessor.Object);

            var result = service.RemoveInAccessibleEntities(collection);

            result.Count.ShouldBe(expectedResults);
            result.LastOrDefault().CreatedBy.ShouldBe(userName);
        }
    }
}
