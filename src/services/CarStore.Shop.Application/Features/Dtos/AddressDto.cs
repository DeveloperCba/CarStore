namespace CarStore.Shop.Application.Features.Brand.Dtos;

public class AddressDto  
{
    public Guid Id { get; set; }
    public string Street { get;  set; }
    public string Number { get;  set; }
    public string Complement { get;  set; }
    public string Neighborhood { get;  set; }
    public string ZipCode { get;  set; }
    public string City { get;  set; }
    public string State { get;  set; }
    public Guid OwnerId { get;  set; }
    public OwnerDto Owner { get;  set; }
  
}