using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
  public class Address : ValueObject
  {
    public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
    {
      Street = street;
      Number = number;
      Neighborhood = neighborhood;
      City = city;
      State = state;
      Country = country;
      ZipCode = zipCode;

      AddNotifications(new Contract()
        .Requires()
        .HasMinLen(Street, 3, "Address.Street", "A rua deve conter ao menos 3 caracteres.")
        .HasMinLen(Neighborhood, 3, "Address.Neighborhood", "O bairro deve conter ao menos 3 caracteres.")
        .HasMinLen(City, 3, "Address.City", "A cidade deve conter ao menos 3 caracteres.")
        .HasMinLen(State, 3, "Address.State", "O estado deve conter ao menos 3 caracteres.")
        .HasMinLen(Country, 3, "Address.Country", "O país deve conter ao menos 3 caracteres.")
        .HasMinLen(ZipCode, 5, "Address.ZipCode", "O código postal deve conter ao menos 5 caracteres.")
      );
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
  }
}
