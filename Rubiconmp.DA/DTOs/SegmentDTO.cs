using System.ComponentModel.DataAnnotations;

namespace Rubiconmp.DA.DTOs;

public class SegmentDTO
{
    [Required] public double StartX { get; set; }
    [Required] public double StartY { get; set; }
    [Required] public double EndX { get; set; }
    [Required] public double EndY { get; set; }
}