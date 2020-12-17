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
      var email = new Email("thisisnotavalidemail");

      Assert.IsTrue(email.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddressIsAValidEmailAddress()
    {
      var email = new Email("this.is@valid.email");

      Assert.IsTrue(email.Valid);
    }
  }
}
