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
    public class ContractServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private MusicProducerResource MusicProducer { get; set; }
        private VideoProducerResource VideoProducer { get; set; }
        private ContractsResource Contract { get; set; }
        
        public ContractServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/contracts is available")]
        public void GivenTheEndpointHttpsLocalhostApiVContractsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/contracts");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [Given(@"A MusicProducer for Contract is already stored")]
        public async void GivenAMusicProducerForContractIsAlreadyStored(Table saveMusicProducerResource)
        {
            // Seed
            var musicproducerUri = new Uri("https://localhost:5001/api/v1/musicproducers");
            
            var resource = saveMusicProducerResource.CreateSet<SaveMusicProducerResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var musicproducerResponse = Client.PostAsync(musicproducerUri, content);
            var musicproducerResponseData = await musicproducerResponse.Result.Content.ReadAsStringAsync();
            var existingMusicProducer = JsonConvert.DeserializeObject<MusicProducerResource>(musicproducerResponseData);
            existingMusicProducer.Id = 1;
            MusicProducer = existingMusicProducer;
        }

        [Given(@"A VideoProducer for Contract is already stored")]
        public async void GivenAVideoProducerForContractIsAlreadyStored(Table saveVideoProducerResource)
        {
            // Seed
            var videoproducerUri = new Uri("https://localhost:5001/api/v1/videoproducers");
            
            var resource = saveVideoProducerResource.CreateSet<SaveVideoProducerResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var videoproducerResponse = Client.PostAsync(videoproducerUri, content);
            var videoproducerResponseData = await videoproducerResponse.Result.Content.ReadAsStringAsync();
            var existingVideoProducer = JsonConvert.DeserializeObject<VideoProducerResource>(videoproducerResponseData);
            existingVideoProducer.Id = 1;
            VideoProducer = existingVideoProducer;
        }

        [When(@"a Contract Post Request is sent")]
        public void WhenAContractPostRequestIsSent(Table saveContractResource)
        {
            var resource = saveContractResource.CreateSet<SaveContractsResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Contract Response with Status (.*) is received")]
        public void ThenAContractResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Contract Resource is included in Response Body")]
        public async void ThenAContractResourceIsIncludedInResponseBody(Table expectedContractResource)
        {
            var expectedResource = expectedContractResource.CreateSet<ContractsResource>().First();
            expectedResource.musicProducerId = MusicProducer.Id;
            expectedResource.videoProducerId = VideoProducer.Id;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<ContractsResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }
    }
}