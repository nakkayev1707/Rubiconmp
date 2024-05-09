using Microsoft.AspNetCore.Mvc;
using Rubiconmp.BL.Services.Abstract;
using Rubiconmp.DA.DTOs;

namespace Rubiconmp.API.Controllers;

[ApiController]
[Route("api/rectangles")]
public class RectanglesController(IRectangleService rectangleService) : ControllerBase
{
    [HttpPost("segment/intersects")]
    public async Task<IActionResult> IntersectsAsync([FromBody] SegmentDTO segmentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Provide required fields please");
        }
        
        List<RectangleDTO> rectangles = await rectangleService.GetSegmentIntersectsAsync(segmentDto);

        if (!rectangles.Any()) return NoContent();
        
        return Ok(rectangles);
    }
}