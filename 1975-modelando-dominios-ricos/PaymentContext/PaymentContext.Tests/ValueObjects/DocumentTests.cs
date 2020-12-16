using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
  [TestClass]
  public class DocumentTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJDoesnNotHaveFourteenCharacters()
    {
      var document = new Document("", EDocumentType.CNPJ);

      Assert.IsTrue(document.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJHasFourteenCharacters()
    {
      var document = new Document("12345678901234", EDocumentType.CNPJ);

      Assert.IsTrue(document.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFDoesnNotHaveElevenCharacters()
    {
      var document = new Document("", EDocumentType.CPF);

      Assert.IsTrue(document.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCPFHasElevenCharacters()
    {
      var document = new Document("12345678901", EDocumentType.CPF);

      Assert.IsTrue(document.Valid);
    }
  }
}
