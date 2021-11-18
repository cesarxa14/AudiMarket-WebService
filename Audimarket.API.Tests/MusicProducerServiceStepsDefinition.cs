using AudiMarket;
using AudiMarket.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Audimarket.API.Tests
{  
    [Binding]
    public class MusicProducerServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private HttpResponseMessage Response { get; set; }

        public MusicProducerServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the endpoint http://localhost:(.*)/api/v(.*)/musicproducers")]
        public void GivenTheEndpointHttpLocalhostApiVMusicproducers(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/musicproducers");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });
        }
        [When(@"a Music Producer Request is sent")]
        public async void WhenAMusicProducersRequestIsSent(Table saveMusicProducerResource)
        {
            var resource = saveMusicProducerResource.CreateSet<SaveMusicProducerResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);
            Response = await _client.PostAsync(_baseUri, content);
        }
        [Then(@"A response with Status (.*) is received")]
        public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
            var actualStatusCode = Response.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
        [Then(@"A music producer resource is included in Response body")]
        public async void ThenAMusicProducerResourceIsIncludedInResponseBody(Table expectedMusicProducerResource)
        {
            var expectedResource = expectedMusicProducerResource.CreateSet<MusicProducerResource>().First();
            var responseData = await Response.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<MusicProducerResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
           // Assert.Equal(expectedResource.Firstname, resource.Firstname);
            //Assert.Equal(expectedResource.Lastname, resource.Lastname);
        }
    }
}
