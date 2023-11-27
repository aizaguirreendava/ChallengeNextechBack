using Microsoft.AspNetCore.Mvc;
using Moq;
using NewsApi;
using NewsApi.Controllers;

namespace Test
{
    public class NewsTest
    {

        [Fact]
        public async Task StoriesController_Should_ReturnCorrectValue()
        {
            // Arrange
            List<Item> listItem = new List<Item>
            {
                new() { title = "Collaborative Fact Checking Platform", url = "https://captainfact.io/"}
            };

            Mock<IStoriesService> mockStoriesService = new();
            mockStoriesService.Setup(mock => mock.GetStories()).ReturnsAsync(listItem);

            StoriesController storiesController = new(mockStoriesService.Object);

            // Act
            var response = await storiesController.GetAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(response);
            var actualStories = Assert.IsAssignableFrom<IEnumerable<Item>>(okResult.Value);
            Assert.Equal(listItem.Count, actualStories.Count());
        }
    }
}