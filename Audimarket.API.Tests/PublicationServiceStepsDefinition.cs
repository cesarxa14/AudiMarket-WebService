using AudiMarket;
using AudiMarket.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Audimarket.API.Tests
{
    [Binding]
    class PublicationServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private HttpResponseMessage Response { get; set; }

        public PublicationServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the endpoint https://localhost:(.*)/api/publications is available")]
        public void GivenTheEndpointHttpsLocalhostApiPublicationsIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/publications");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });
        }
        [When(@"a Post Request is sent")]
        public async void WhenAPublicationRequestIsSent(Table savePublicationResource)
        {
            var resource = savePublicationResource.CreateSet<SavePublicationResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);
            Response = await _client.PostAsync(_baseUri, content);
        }
        [Then(@"a response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
            var actualStatusCode = Response.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
        [Then(@"a publication resource is included  in Response body")]
        public async void ThenAPublicationResourceIsIncludedInResponseBody(Table expectedPublicationResource)
        {
            var expectedResource = expectedPublicationResource.CreateSet<PublicationResource>().First();
            var responseData = await Response.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<PublicationResource>(responseData);
            Assert.Equal(expectedResource.Description, resource.Description);
        }

    }
}
