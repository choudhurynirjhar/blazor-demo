using Blazor.Demo.Pages;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Blazor.Demo.UnitTest
{
    public class Tests
    {
        private Bunit.TestContext testContext;
        private Mock<ILoginProcessor> loginProcessor;

        [SetUp]
        public void Setup()
        {
            testContext = new Bunit.TestContext();
            loginProcessor = new Mock<ILoginProcessor>();
        }

        [TearDown]
        public void Teardown()
        {
            testContext.Dispose();
        }

        [Test]
        public void No_Email_Password_Condition()
        {
            testContext.Services.AddScoped(x => loginProcessor.Object);

            var component = testContext.RenderComponent<Index>();

            Assert.IsTrue(component.Markup.Contains("<h1>Hello, world!</h1>"));

            var buttons = component.FindAll("button");
            Assert.AreEqual(1, buttons.Count);

            var submit = buttons.FirstOrDefault(b => b.OuterHtml.Contains("Submit"));
            Assert.IsNotNull(submit);

            submit.Click();
            loginProcessor.Verify(l => l.Login(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Proper_Email_Password_Condition()
        {
            testContext.Services.AddScoped(x => loginProcessor.Object);

            var component = testContext.RenderComponent<Index>();

            var buttons = component.FindAll("button");
            var submit = buttons.FirstOrDefault(b => b.OuterHtml.Contains("Submit"));

            var email = component.Find("#agentEmail");
            email.Change("testemail");

            var password = component.Find("#agentPassword");
            password.Change("TestPassword");

            loginProcessor.Setup(l => l.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            submit.Click();
            loginProcessor.Verify(l => l.Login(It.IsAny<string>(), It.IsAny<string>()), Times.Once);

            var alert = component.Find("div.alert");
            Assert.AreEqual("Invalid login", alert.InnerHtml);
        }
    }
}