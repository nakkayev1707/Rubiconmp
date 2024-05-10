using Microsoft.EntityFrameworkCore;
using Rubiconmp.BL.Services;
using Rubiconmp.DA.DBContext;
using Rubiconmp.DA.DTOs;
using Rubiconmp.DA.Models;
using Xunit;

namespace Rubiconmp.Tests.Services;

public class RectangleServiceTests
{
    [Fact]
    public async Task GetSegmentIntersectsAsync_ReturnsCorrectRectangles()
    {
        var options = new DbContextOptionsBuilder<ApplicationDBContext>()
            .UseInMemoryDatabase(databaseName: "rubiconmp-test-db")
            .Options;
            
        using (var dbContext = new ApplicationDBContext(options))
        {
            dbContext.Rectangles.AddRange(new List<Rectangle>
            {
                new() { Id = 1, X = 0, Y = 0, Width = 5, Height = 5 },
                new() { Id = 2, X = 6, Y = 6, Width = 5, Height = 5 },
                new() { Id = 3, X = 2, Y = 2, Width = 5, Height = 5 },
            });
            await dbContext.SaveChangesAsync();
        }

        using (var dbContext = new ApplicationDBContext(options))
        {
            var service = new RectangleService(dbContext);
            var segment = new SegmentDTO { StartX = 1, StartY = 1, EndX = 4, EndY = 4 };

            List<RectangleDTO> result = await service.GetSegmentIntersectsAsync(segment);

            Assert.Equal(2, result.Count);
            Assert.Contains(result, r => r.Id == 1);
            Assert.Contains(result, r => r.Id == 3);
        }
    }
}