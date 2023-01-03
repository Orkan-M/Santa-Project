using Microsoft.AspNetCore.Components.RenderTree;
using Moq;
using Santa_Project.Data.Reindeer;
using Santa_Project.Models.Reindeer;

namespace Santa_Project.Tests
{
    public class ReindeerTests
    {

        [Fact]
        public void GetReindeer()
        {
            var Reindeer = new ReindeerModel
            {
                Name = Guid.NewGuid().ToString(),
                Capacity = 200,
                Range = 20,
                ShinyNose = true
            };

            var mockProvider = new Mock<IReindeerProvider>();
            mockProvider.Setup(provider => provider.LoadJson())
                .Returns(new List<ReindeerModel> { Reindeer });


            var sut = new ReindeerRepository(mockProvider.Object);

            var result = sut.GetReindeerByName(Reindeer.Name);

            Assert.Equal(Reindeer, result);

        }

        [Fact]
        public void GetReindeerInvalidName()
        {
            var mockProvider = new Mock<IReindeerProvider>();
            mockProvider.Setup(provider => provider.LoadJson())
                .Returns(new List<ReindeerModel>());

            var sut = new ReindeerRepository(mockProvider.Object);

            Assert.Throws<ArgumentException>(() => sut.GetReindeerByName("Reindeer Name"));

        }

        [Fact]
        public void AddReindeer()
        {
            var Reindeer = new ReindeerModel
            {
                Name = Guid.NewGuid().ToString(),
                Capacity = 200,
                Range = 20,
                ShinyNose = true
            };

            var mockProvider = new Mock<IReindeerProvider>();
            mockProvider.Setup(provider => provider.LoadJson())
                .Returns(new List<ReindeerModel>());

            var sut = new ReindeerRepository(mockProvider.Object);

            var result = sut.AddReindeer(Reindeer);

            Assert.Equal(Reindeer, result);

        }

        [Fact]
        public void AddReindeerInvalidName()
        {
            var duplicateReindeer = new ReindeerModel
            {
                Name = "Dasher",
                Capacity = 200,
                Range = 20,
                ShinyNose = true
            };

            var mockProvider = new Mock<IReindeerProvider>();
            mockProvider.Setup(provider => provider.LoadJson())
                .Returns(new List<ReindeerModel>{duplicateReindeer});

            var sut = new ReindeerRepository(mockProvider.Object);

            Assert.Throws<ArgumentException>(() => sut.AddReindeer(duplicateReindeer));

        }

        [Fact]
        public void RemoveReindeer()
        {
            var Reindeer = new ReindeerModel
            {
                Name = "Dasher",
                Capacity = 200,
                Range = 20,
                ShinyNose = true
            };
            var reindeerList = new List<ReindeerModel> { Reindeer };

            var mockProvider = new Mock<IReindeerProvider>();
            mockProvider.Setup(provider => provider.LoadJson())
                .Returns(reindeerList);

            var sut = new ReindeerRepository(mockProvider.Object);

            sut.RemoveReindeer("Dasher");

            Assert.DoesNotContain(Reindeer,reindeerList);
            Assert.Empty(reindeerList);
        }

        [Fact]
        public void RemoveReindeerNotInList()
        {

            var mockProvider = new Mock<IReindeerProvider>();
            mockProvider.Setup(provider => provider.LoadJson())
                .Returns(new List<ReindeerModel>());

            var sut = new ReindeerRepository(mockProvider.Object);

            Assert.Throws<ArgumentException>(() => sut.RemoveReindeer("Invalid name"));

        }

        [Fact]
        public void EditReindeer()
        {
            var reindeer = new ReindeerModel
            {
                Name = "Test",
                Capacity = 200,
                Range = 20,
                ShinyNose = true
            };

            var mockProvider = new Mock<IReindeerProvider>();
            mockProvider.Setup(provider => provider.LoadJson())
                .Returns(new List<ReindeerModel> { reindeer });

            var sut = new ReindeerRepository(mockProvider.Object);

            var reindeerToEdit = new ReindeerModel
            {
                Name = "Test",
                Capacity = 100,
                Range = 10,
                ShinyNose = false
            };


            var result = sut.EditReindeer(reindeerToEdit);

            Assert.Equal(reindeerToEdit, result);
        }

        [Fact]
        public void EditReindeerInvalidName()
        {
            var reindeerToEdit = new ReindeerModel
            {
                Name = "Test",
                Capacity = 100,
                Range = 10,
                ShinyNose = false
            };

            var mockProvider = new Mock<IReindeerProvider>();
            mockProvider.Setup(provider => provider.LoadJson())
                .Returns(new List<ReindeerModel>());

            var sut = new ReindeerRepository(mockProvider.Object);

            Assert.Throws<ArgumentException>(() => sut.EditReindeer(reindeerToEdit));

        }
    }
}


