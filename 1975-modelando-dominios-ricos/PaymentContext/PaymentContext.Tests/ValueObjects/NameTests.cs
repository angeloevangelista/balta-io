using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
  [TestClass]
  public class NameTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenFirstNameHasLessThanThreeCharacters()
    {
      var name = new Name("", "MacGyver");

      Assert.IsTrue(name.Invalid);
    }

    public void ShouldReturnErrorWhenFirstNameHasMoreThanFortyCharacters()
    {
      var name = new Name("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "MacGyver");

      Assert.IsTrue(name.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenFirstNameIsBetweenThreeAndFortyCharacters()
    {
      var name = new Name("Angus", "MacGyver");

      Assert.IsTrue(name.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenLastNameHasLessThanThreeCharacters()
    {
      var name = new Name("Angus", "");

      Assert.IsTrue(name.Invalid);
    }

    public void ShouldReturnErrorWhenLastNameHasMoreThanFortyCharacters()
    {
      var name = new Name("Angus", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

      Assert.IsTrue(name.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenLastNameIsBetweenThreeAndFortyCharacters()
    {
      var name = new Name("Angus", "MacGyver");

      Assert.IsTrue(name.Valid);
    }
  }
}
