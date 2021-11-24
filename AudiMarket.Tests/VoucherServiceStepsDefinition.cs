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
    public class VoucherServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private PayMethodResource PayMethod { get; set; }
        private ContractsResource Contract { get; set; }
        private VoucherResource Voucher { get; set; }
        
        public VoucherServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/vouchers is available")]
        public void GivenTheEndpointHttpsLocalhostApiVVouchersIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/vouchers");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [Given(@"A PayMethod for Voucher is already stored")]
        public async void GivenAPayMethodForVoucherIsAlreadyStored(Table savePayMethodResource)
        {
            // Seed
            var paymethodUri = new Uri("https://localhost:5001/api/v1/paymethods");
            
            var resource = savePayMethodResource.CreateSet<SavePayMethodResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var paymethodResponse = Client.PostAsync(paymethodUri, content);
            var paymethodResponseData = await paymethodResponse.Result.Content.ReadAsStringAsync();
            var existingPayMethod = JsonConvert.DeserializeObject<PayMethodResource>(paymethodResponseData);
            existingPayMethod.IdPayMethod = 1;
            PayMethod = existingPayMethod;
        }

        [Given(@"A Contract for Voucher is already stored")]
        public async void GivenAContractForVoucherIsAlreadyStored(Table saveContractResource)
        {
            // Seed
            var contractUri = new Uri("https://localhost:5001/api/v1/contracts");
            
            var resource = saveContractResource.CreateSet<SaveContractsResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var contractResponse = Client.PostAsync(contractUri, content);
            var contractResponseData = await contractResponse.Result.Content.ReadAsStringAsync();
            var existingContract = JsonConvert.DeserializeObject<ContractsResource>(contractResponseData);
            existingContract.Id = 1;
            Contract = existingContract;
        }

        [When(@"a Voucher Post Request is sent")]
        public void WhenAVoucherPostRequestIsSent(Table saveVoucherResource)
        {
            var resource = saveVoucherResource.CreateSet<SaveVoucherResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Voucher Response with Status (.*) is received")]
        public void ThenAVoucherResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Voucher Resource is included in Response Body")]
        public async void ThenAVoucherResourceIsIncludedInResponseBody(Table expectedVoucherResource)
        {
            var expectedResource = expectedVoucherResource.CreateSet<VoucherResource>().First();
            expectedResource.PayMethodId = PayMethod.IdPayMethod;
            expectedResource.ContractId = Contract.Id;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<VoucherResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }
    }
}