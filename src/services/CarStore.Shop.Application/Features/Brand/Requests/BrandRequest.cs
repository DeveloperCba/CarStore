using System.ComponentModel.DataAnnotations;

namespace CarStore.Shop.Application.Features.Brand.Requests;

public class BrandRequest
{
    [Required(ErrorMessage = "The {PropertyName} field is mandatory.")]
    public required string Name { get; set; }
    public int Status { get; set; }
}