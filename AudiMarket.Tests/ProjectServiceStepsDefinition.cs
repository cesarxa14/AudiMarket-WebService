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
    public class ProjectServiceStepsDefinition
    {
        
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private PlayListResource PlayList { get; set; }
        private ProjectResource Project { get; set; }
        
        public ProjectServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/projects is available")]
        public void GivenTheEndpointHttpsLocalhostApiVProjectsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/projects");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [Given(@"A PlayList for Project is already stored")]
        public async void GivenAPlayListForProjectIsAlreadyStored(Table savePlayListResource)
        {
            // Seed
            var playlistUri = new Uri("https://localhost:5001/api/v1/playlists");
            
            var resource = savePlayListResource.CreateSet<SavePlayListResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var playlistResponse = Client.PostAsync(playlistUri, content);
            var playlistResponseData = await playlistResponse.Result.Content.ReadAsStringAsync();
            var existingPlayList = JsonConvert.DeserializeObject<PlayListResource>(playlistResponseData);
            existingPlayList.Id = 1;
            PlayList = existingPlayList;
        }

        [When(@"a Project Post Request is sent")]
        public void WhenAProjectPostRequestIsSent(Table saveProjectResource)
        {
            var resource = saveProjectResource.CreateSet<SaveProjectResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Project Response with Status (.*) is received")]
        public void ThenAProjectResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Project Resource is included in Response Body")]
        public async void ThenAProjectResourceIsIncludedInResponseBody(Table expectedProjectResource)
        {
            var expectedResource = expectedProjectResource.CreateSet<ProjectResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<ProjectResource>(responseData);
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