using PlannR.App.Infrastructure.Contracts.View;
using PlannR.App.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.App.Tests.Services
{
    public class MapServiceUnitTests
    {
        private readonly IMapService _mapService;

        public MapServiceUnitTests()
        {
            _mapService = new MapService();
        }

        [Fact]
        public void WHEN_Invalid_values_are_passed_in_THEN_zero_values_are_returned()
        {
            var value = "xxx";

            var result = _mapService.ParseCoordinates(value);

            result.Item1.ShouldBe(0);
            result.Item2.ShouldBe(0);
        }

        [InlineData("1.1 0.1")]
        [InlineData("1,1 0.1")]
        [InlineData("1.1 0,1")]
        [InlineData("1,1 0,1")]
        [Theory]
        public void WHEN_Varied_Cultered_Number_strings_are_passed_in_THEN_all_values_should_be_successful(
            string value)
        {
            var result = _mapService.ParseCoordinates(value);

            result.Item1.ShouldBe(ParseParam(value, 1));
            result.Item2.ShouldBe(ParseParam(value, 0));
        }
        private double ParseParam(string value, int pos)
        {
            var splitValue = value.Split(' ');
            var strValue = splitValue[pos].Replace(',', '.');
            return double.Parse(strValue);
        }
    }
}
