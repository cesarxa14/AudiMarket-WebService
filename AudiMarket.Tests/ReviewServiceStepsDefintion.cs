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
    public class ReviewServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private MusicProducerResource MusicProducer { get; set; }
        private VideoProducerResource VideoProducer { get; set; }
        private ReviewResource Review { get; set; }
        
        public ReviewServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/reviews is available")]
        public void GivenTheEndpointHttpsLocalhostApiVReviewsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/reviews");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [Given(@"A MusicProducer for Review is already stored")]
        public async void GivenAMusicProducerForReviewIsAlreadyStored(Table saveMusicProducerResource)
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

        [Given(@"A VideoProducer for Review is already stored")]
        public async void GivenAVideoProducerForReviewIsAlreadyStored(Table saveVideoProducerResource)
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

        [When(@"a Review Post Request is sent")]
        public void WhenAReviewPostRequestIsSent(Table saveReviewResource)
        {
            var resource = saveReviewResource.CreateSet<SaveReviewResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Review Response with Status (.*) is received")]
        public void ThenAReviewResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Review Resource is included in Response Body")]
        public async void ThenAReviewResourceIsIncludedInResponseBody(Table expectedReviewResource)
        {
            var expectedResource = expectedReviewResource.CreateSet<ReviewResource>().First();
            expectedResource.MusicProducer = MusicProducer;
            expectedResource.VideoProducer = VideoProducer;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<ReviewResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }
    }
}