using Rubiconmp.DA.DTOs;

namespace Rubiconmp.BL.Services.Abstract;

public interface IRectangleService
{
    Task<List<RectangleDTO>> GetSegmentIntersectsAsync(SegmentDTO segmentDto);
}