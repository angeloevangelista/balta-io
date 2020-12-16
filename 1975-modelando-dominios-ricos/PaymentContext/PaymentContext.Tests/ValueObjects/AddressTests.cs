using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
  [TestClass]
  public class AddressTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenStreetHasLessThanThreeCharacters()
    {
      var address = new Address(
        street: "",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      Assert.IsTrue(address.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenStreetHasMoreThanThreeCharacters()
    {
      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      Assert.IsTrue(address.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenNeighborhoodHasLessThanThreeCharacters()
    {
      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      Assert.IsTrue(address.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenNeighborhoodHasMoreThanThreeCharacters()
    {
      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      Assert.IsTrue(address.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCityHasLessThanThreeCharacters()
    {
      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      Assert.IsTrue(address.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCityHasMoreThanThreeCharacters()
    {
      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      Assert.IsTrue(address.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenStateHasLessThanThreeCharacters()
    {
      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "",
        country: "United Status",
        zipCode: "12345"
      );

      Assert.IsTrue(address.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenStateHasMoreThanThreeCharacters()
    {
      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      Assert.IsTrue(address.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCountryHasLessThanThreeCharacters()
    {
      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "",
        zipCode: "12345"
      );

      Assert.IsTrue(address.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCountryHasMoreThanThreeCharacters()
    {
      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      Assert.IsTrue(address.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenZipCodeHasLessThanFiveCharacters()
    {
      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: ""
      );

      Assert.IsTrue(address.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenZipCodeHasMoreThanFiveCharacters()
    {
      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      Assert.IsTrue(address.Valid);
    }
  }
}
