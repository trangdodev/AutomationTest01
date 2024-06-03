using APITestting.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TestFrameworkCore.Helper;

namespace APITestting.Test
{
    [TestClass]
    public class UserAPITest
    {
        private RestClient client;
        [TestInitialize]
        public void TestInitialize()
        {
            var url = ConfigurationHelper.GetConfig<string>("url");
            client = new RestClient(url);
        }
        [TestMethod("TC05: Get List User")]
        public void VerifyGetListUser()
        {

            int randomPage = new Random().Next(1, 11);
            var request = new RestRequest($"/api/users?page={randomPage}", Method.Get);
            RestResponse response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            GetUserModel model = JsonConvert.DeserializeObject<GetUserModel>(response.Content);
            model.page.Should().Be(randomPage);
        }

        [TestMethod("TC06: Create a new user")]
        public void VerifyCreateNewUser()
        {
            var request = new RestRequest("/api/users", Method.Post);

            // Khai báo model và data gửi lên api
            var requestModel = new CreateUserRequestModel
            {
                Name = "Trang" + DateTime.Now.ToFileTimeUtc(),
                Job = "Automation Tester",
            };

            request.AddJsonBody(requestModel);
            RestResponse response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var responeModel = JsonConvert.DeserializeObject<CreateUserResponeModel>(response.Content);
            responeModel.name.Should().Be(requestModel.Name);
            responeModel.job.Should().Be(requestModel.Job);
        }

    }
}
