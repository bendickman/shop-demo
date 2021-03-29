using Moq;
using NUnit.Framework;
using ShopDemo.Api.Core.Commands;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ShopDemo.UnitTests
{
    [TestFixture]
    public class ShopDemoCommandProviderTests
    {
        private Mock<IHttpClientFactory> _httpclientFactory;
        private IEnumerable<ICommand> _availableCommands;
        private ICommandProvider _commandProvider;

        [SetUp]
        public void Setup()
        {
            _httpclientFactory = new Mock<IHttpClientFactory>();

            _availableCommands = new List<ICommand>
            {
                new CategoriesCommand(_httpclientFactory.Object),
                new FeaturedProductsCommand(_httpclientFactory.Object),
                new ProductsByCategoryCommand(_httpclientFactory.Object),
                new NotFoundCommand(),
                new QuitCommand()
            };

            _commandProvider = new ShopDemoCommandProvider(_availableCommands);

        }

        [Test]
        [TestCase("b", typeof(CategoriesCommand))]
        [TestCase("c", typeof(FeaturedProductsCommand))]
        [TestCase("d", typeof(ProductsByCategoryCommand))]
        [TestCase("q", typeof(QuitCommand))]
        [TestCase("z", typeof(NotFoundCommand))]
        public void GetCommand_WhenCalled_ReturnsCorrectCommand(string key, Type expectedcommand)
        {
            var result = _commandProvider.GetCommand(key);

            Assert.AreEqual(result.GetType(), expectedcommand);
        }
    }
}
