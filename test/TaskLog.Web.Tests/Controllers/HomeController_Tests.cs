using System.Threading.Tasks;
using TaskLog.Models.TokenAuth;
using TaskLog.Web.Controllers;
using Shouldly;
using Xunit;

namespace TaskLog.Web.Tests.Controllers
{
    public class HomeController_Tests: TaskLogWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}