using Microsoft.AspNetCore.Mvc;
using Moq;
using Rubiconmp.API.Controllers;
using Rubiconmp.BL.Services.Abstract;
using Rubiconmp.DA.DTOs;
using Xunit;

namespace Rubiconmp.Tests.Controllers;

public class RectanglesControllerTests
{
    [Fact]
    public async Task IntersectsAsync_ValidSegment_ReturnsCorrectResult()
    {
        var segmentDto = new SegmentDTO { StartX = 1, StartY = 1, EndX = 4, EndY = 4 };
        var expectedRectangles = new List<RectangleDTO>
        {
            new() { Id = 1, X = 0, Y = 0, Width = 5, Height = 5 },
            new() { Id = 3, X = 2, Y = 2, Width = 5, Height = 5 }
        };

        var mockRectangleService = new Mock<IRectangleService>();
        mockRectangleService.Setup(service => service.GetSegmentIntersectsAsync(segmentDto))
            .ReturnsAsync(expectedRectangles);

        var controller = new RectanglesController(mockRectangleService.Object);

        var result = await controller.IntersectsAsync(segmentDto);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var actualRectangles = Assert.IsAssignableFrom<List<RectangleDTO>>(okResult.Value);
        Assert.Equal(expectedRectangles.Count, actualRectangles.Count);
    }
}