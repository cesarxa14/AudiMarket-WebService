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
    public class PlayListServiceStepsDefinition
    {
        
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private MusicProducerResource MusicProducer { get; set; }
        private PlayListResource PlayList { get; set; }
        
        public PlayListServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/playlists is available")]
        public void GivenTheEndpointHttpsLocalhostApiVPlayListsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/playlists");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [Given(@"A MusicProducer for PlayList is already stored")]
        public async void GivenAMusicProducerForPlayListIsAlreadyStored(Table saveMusicProducerResource)
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

        [When(@"a PlayList Post Request is sent")]
        public void WhenAPlayListPostRequestIsSent(Table savePlayListResource)
        {
            var resource = savePlayListResource.CreateSet<SavePlayListResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A PlayList Response with Status (.*) is received")]
        public void ThenAPlayListResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A PlayList Resource is included in Response Body")]
        public async void ThenAPlayListResourceIsIncludedInResponseBody(Table expectedPlayListResource)
        {
            var expectedResource = expectedPlayListResource.CreateSet<PlayListResource>().First();
            expectedResource.MusicProducer = MusicProducer;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<PlayListResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }

        [Then(@"a Message of ""(.*)"" is included in Response Body")]
        public async void ThenAMessageOfIsIncludedInResponseBody(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonActualMessage = actualMessage.ToJson();
            var jsonExpectedMessage = expectedMessage.ToJson();
            Assert.Equal(jsonExpectedMessage, jsonActualMessage);
        }
    }
}