using System.ComponentModel.DataAnnotations;

namespace CarStore.Shop.Application.Features.Brand.Requests;

public class UpdateBrandRequest
{
    [Required(ErrorMessage = "The {PropertyName} field is mandatory.")]
    public required Guid Id { get; set; }

    [Required(ErrorMessage = "The {PropertyName} field is mandatory.")]
    public required string Name { get; set; }
    public int Status { get; set; }
}