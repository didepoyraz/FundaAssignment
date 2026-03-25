using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundaWeb.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FundaWeb.Tests.WebApiTests
{
    public class FundaIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public FundaIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Makelaars_Returns_OK()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/makelaars");

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task Get_MakelaarsTuin_Returns_OK()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/makelaars/tuin");

            Assert.True(response.IsSuccessStatusCode);
        }

        
    }
}