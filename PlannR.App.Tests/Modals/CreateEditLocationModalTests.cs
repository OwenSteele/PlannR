//using Blazored.Modal.Services;
//using Microsoft.AspNetCore.Components.Testing;
//using Moq;
//using PlannR.App.Infrastructure.Contracts;
//using PlannR.App.Infrastructure.Services.Base;
//using PlannR.App.Infrastructure.ViewModels.Locations;
//using PlannR.App.Pages.Modals;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace PlannR.App.Tests.Modals
//{
//    public class CreateEditLocationModalTests
//    {
//        private readonly TestHost _host;
//        private IModalService _modalService;
//        private Mock<ILocationDataService> _mockLocationDataService;

//        public CreateEditLocationModalTests()
//        {
//            _host = new TestHost();

//            _modalService = new ModalService();
//            _host.AddService(_modalService);

//            _mockLocationDataService = new();
//        }

//        [Fact]
//        public async Task WHEN_persist_new_location_response_is_not_successful_THEN_modal_remains_open()
//        {
//            var modal = _host.AddComponent<CreateEditLocationModal>();
//            var modalInstance = modal.Instance;

//            _mockLocationDataService.Setup(x => x.CreateAsync(It.IsAny<EditLocationViewModel>()))
//                .ReturnsAsync(new ApiResponse<Guid> { 
//                    Data = Guid.Empty,
//                    Success = false,
//                    Errors = "Error",
//                    Message = "Error"
//                });

//            _host.AddService(_mockLocationDataService);
//        }
//    }
//}
