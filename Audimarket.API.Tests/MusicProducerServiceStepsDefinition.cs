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
    class MusicProducerServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private HttpResponseMessage Response { get; set; }

        public MusicProducerServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/musicproducers is available")]
        public void GivenTheEndpointHttpsLocalhostApiMusicProducersIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/musicproducers");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });
        }
        [When(@"a Music Producers Request is sent")]
        public async void WhenAMusicProducersRequestIsSent(Table saveMusicProducerResource)
        {
            var resource = saveMusicProducerResource.CreateSet<SaveMusicProducerResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);
            Response = await _client.PostAsync(_baseUri, content);
        }
        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
            var actualStatusCode = Response.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
        [Then(@"A Music Producer Resource is included  in Response Body")]
        public async void ThenAMusicProducerResourceIsIncludedInResponseBody(Table expectedMusicProducerResource)
        {
            var expectedResource = expectedMusicProducerResource.CreateSet<MusicProducerResource>().First();
            var responseData = await Response.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<MusicProducerResource>(responseData);
            Assert.Equal(expectedResource.Firstname, resource.Firstname);
            Assert.Equal(expectedResource.Lastname, resource.Lastname);
        }
    }
}
