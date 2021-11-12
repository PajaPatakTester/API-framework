using api_framework.Models;
using Common;
using FluentAssertions;
using RestSharp;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class GetResponsesSteps
    {
        WeatherDTO responseBody = null; 

        [Given(@"I create request with parameter '(.*)' and its value '(.*)'")]
        public void GivenICreateRequestWithParameterAndItsValue(string parameter, string value)
        {
            Utility.Request = new RestRequest();
            Utility.Client = new RestClient();
            Utility.Request.AddParameter(parameter, value);
        }

        [When(@"I send this request")]
        public void WhenISendThisRequest()
        {
            Utility.Response = ApiCalls.Get();
        }

        [Then(@"Result should be response Status (.*)")]
        public void ThenResultShouldBeResponseStatus(HttpResponses statusCode)
        {
            Utility.Response.StatusCode.Should().Be(statusCode);
        }

        [Then(@"Result should be adequate body")]
        public void ThenResultShouldBeAdequateBody()
        {
            responseBody = CommonActions.DeserilizeJsonCamelCase<WeatherDTO>(Utility.Response.Content);
            responseBody.Should().NotBeNull();
        }

        [Then(@"City in response should be '(.*)'")]
        public void ThenCityInResponseShouldBe(string city)
        {
            responseBody.Name.Should().Be(city);
        }

    }
}
