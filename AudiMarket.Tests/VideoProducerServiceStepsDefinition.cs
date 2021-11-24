using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AudiMarket.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace AudiMarket.Tests
{
    [Binding]
    public class VideoProducerServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private VideoProducerResource VideoProducer { get; set; }
        
        public VideoProducerServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/videoproducers is available")]
        public void GivenTheEndpointHttpsLocalhostApiVVideoproducersIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/videoproducers");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [Then(@"A VideoProducer Resource is included in Response Body")]
        public async void ThenAVideoProducerResourceIsIncludedInResponseBody(Table expectedVideoProducerResource)
        {
            var expectedResource = expectedVideoProducerResource.CreateSet<VideoProducerResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<VideoProducerResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }
        
        [When(@"a VideoProducer Post Request is sent")]
        public void WhenAVideoProducerPostRequestIsSent(Table saveVideoProducerResource)
        {
            var resource = saveVideoProducerResource.CreateSet<SaveVideoProducerResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A VideoProducer Response with Status (.*) is received")]
        public void ThenAVideoProducerResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}