using Microsoft.EntityFrameworkCore;
using Rubiconmp.BL.Services.Abstract;
using Rubiconmp.DA.DBContext;
using Rubiconmp.DA.DTOs;
using Rubiconmp.DA.Models;

namespace Rubiconmp.BL.Services;

public class RectangleService : IRectangleService
{
    private readonly ApplicationDBContext _dbContext;

    public RectangleService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<RectangleDTO>> GetSegmentIntersectsAsync(SegmentDTO segment)
    {
        if (segment == null) throw new ArgumentNullException(nameof(segment));
        
        double minX = Math.Min(segment.StartX, segment.EndX);
        double maxX = Math.Max(segment.StartX, segment.EndX);
        double minY = Math.Min(segment.StartY, segment.EndY);
        double maxY = Math.Max(segment.StartY, segment.EndY);

        List<RectangleDTO> rectangles = await _dbContext.Rectangles
            .AsNoTracking()
            .Where(rectangle => minX <= rectangle.X + rectangle.Width &&
                                maxX >= rectangle.X &&
                                minY <= rectangle.Y + rectangle.Height &&
                                maxY >= rectangle.Y)
            .Select(rectangle => new RectangleDTO
            {
                Id = rectangle.Id,
                X = rectangle.X,
                Y = rectangle.Y,
                Height = rectangle.Height,
                Width = rectangle.Width
            }).ToListAsync();

        return rectangles;
    }
}