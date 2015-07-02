using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using Moq;
using NUnit.Framework;

namespace Routing.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            var mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            var mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object); 
            return mockContext.Object;
        }

        public void CheckRoute(string url, string controller, string action, object routeProperties = null, string httpMethod = "GET")
        {
           //Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //Act

            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            //Assert

            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet = null)
        {
            Func<object, object, bool> valCompare = (v1, v2) => StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0; 
            bool result = valCompare(routeResult.Values["controller"], controller) && valCompare(routeResult.Values["action"], action); 
            if (propertySet != null)
            {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                if (propInfo.Any(pi => !(routeResult.Values.ContainsKey(pi.Name) &&
                                         valCompare(routeResult.Values[pi.Name], pi.GetValue(propertySet, null)))))
                {
                    result = false;
                }
            }
            return result;
        }

        [Test]
        public void TestHomeUrl()
        {
            CheckRoute("~/Home/Index", "Home", "Index");
        }
    }
}
