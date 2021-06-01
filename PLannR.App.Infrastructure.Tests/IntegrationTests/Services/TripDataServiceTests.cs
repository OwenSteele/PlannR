using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Moq;
using PlannR.App.Infrastructure.Authentication;
using PlannR.App.Infrastructure.Profiles;
using PlannR.App.Infrastructure.Services;
using PlannR.App.Infrastructure.Services.Base;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PLannR.App.Infrastructure.Tests.IntegrationTests.Services
{
    public class TripDataServiceTests
    {
        private IMapper _mapper;

        [Fact]
        public async Task WHEN_all_trips_are_requested_from_httpClient_THEN_all_trips_are_returned_as_viewModels()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

            var httpClient = new HttpClient();

            var trips = new List<TripListDataModel>
            {
                new TripListDataModel
                {
                    TripId = Guid.NewGuid(),
                    Name = "1",
                    StartDateTime = DateTime.Now,
                    EndDateTime = DateTime.Now.AddDays(1)
                },
                new TripListDataModel
                {
                    TripId = Guid.NewGuid(),
                    Name = "2",
                    StartDateTime = DateTime.Now.AddYears(1),
                    EndDateTime = DateTime.Now.AddYears(1).AddDays(1),
                    StartLocation = new LocationDto {Name = "start"},
                    EndLocation = new LocationDto {Name = "end"}
                }
            };

            var mockClient = new Mock<IClient>();

            mockClient.Setup(x => x.GetAllTripsAsync())
                .ReturnsAsync(() =>
                {
                    return new List<TripListDataModel>();
                });

            var mockLocalStorage = new Mock<ILocalStorageService>();

            mockLocalStorage.Setup(x => x.ContainKeyAsync(It.IsAny<string>()))
                .ReturnsAsync(() =>
                {
                    return false;
                });

            AuthenticationStateProvider stateProvider = new PlannrAuthenticationStateProvider(mockLocalStorage.Object);

            var tripDataService = new TripDataService(_mapper, mockClient.Object, stateProvider);

            var result = await tripDataService.GetAllTripsAsync();
        }
    }
}
