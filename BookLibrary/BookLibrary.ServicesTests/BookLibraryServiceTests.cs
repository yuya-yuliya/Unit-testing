using BookLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BookLibrary.Dal;
using Moq;
using BookLibrary.Models;

namespace BookLibrary.Services.Tests
{
    [TestFixture]
    public class BookLibraryServiceTests
    {
        private Mock<IBookLibraryRepository> mockRepository;
        private IBookLibraryService service;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new Mock<IBookLibraryRepository>();
            this.service = new BookLibraryService(this.mockRepository.Object);
        }

        [Test]
        public void AddAsyncTest_NameIsNull_Throws()
        {
            // Arrange

            // Act
            AsyncTestDelegate testDelegate = async () => await this.service.AddAsync(null, null);

            // Assert
            Assert.ThrowsAsync<ArgumentException>(testDelegate);
        }

        [Test]
        public async Task AddAsync_ValidParameter_SuccessAsync()
        {
            // Arrange
            this.mockRepository.Setup(x => x.AddAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Book { Id = 42 });

            // Act
            var result = await this.service.AddAsync("test name", "test content");

            // Assert
            Assert.AreEqual(42, result);
        }
    }
}