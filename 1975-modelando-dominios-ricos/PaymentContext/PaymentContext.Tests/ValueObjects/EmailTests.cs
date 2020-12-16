using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
  [TestClass]
  public class EmailTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenAddressIsNotAVAlidEmaillAddress()
    {
      var name = new Email("thisisnotavalidemail");

      Assert.IsTrue(name.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddressIsAValidEmailAddress()
    {
      var name = new Email("this.is@valid.email");

      Assert.IsTrue(name.Valid);
    }
  }
}
