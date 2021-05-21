using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlannR.Application.Tests.ATETypes.Mocks
{
    public class TypeRespositoryMocks
    {
        // As the three ATE-Type types are Identical in CQ, only testing one as all have same functionality
        //ATE-Type == AccomodationTypeType, TransportType, EventType
        public static Mock<IAsyncRepository<AccomodationType>> GetAccomodationTypeRepository()
        {
            var t1 = Guid.Parse("{0c135c86-f44c-47e9-9305-15527126c239}");
            var t2 = Guid.Parse("{2545332f-3f7d-4f99-bfa9-ae5ec3cc7e0d}");

            var accoms = new List<AccomodationType>
            {
                new AccomodationType
                {
                    AccomodationTypeId = t1,
                    Name = "accomType 1"
                },
                new AccomodationType
                {
                    AccomodationTypeId = t2,
                    Name = "accomType 2"
                }
            };

            var mockRepository = new Mock<IAsyncRepository<AccomodationType>>();

            mockRepository.Setup(x => x.ListAllAsync()).ReturnsAsync(accoms);

            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid guid) =>
                {
                    return accoms.FirstOrDefault(x => x.AccomodationTypeId == guid);
                });

            mockRepository.Setup(x => x.AddAsync(It.IsAny<AccomodationType>()))
                .ReturnsAsync((AccomodationType accomodation) =>
                {
                    accoms.Add(accomodation);
                    return accomodation;
                }
                );

            return mockRepository;
        }
    }
}
