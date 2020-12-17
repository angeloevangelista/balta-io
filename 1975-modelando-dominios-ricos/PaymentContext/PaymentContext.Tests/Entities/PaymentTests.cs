using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
  [TestClass]
  public class PaymentTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenTotalIsLowerOrEqualsZero()
    {
      var email = new Email("this.is@valid.email");

      var document = new Document("12345678901", EDocumentType.CPF);

      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      // Its necessary to use a class which extends Payment 'cause its abstract
      var payment = new PayPalPayment(
        email,
        transactionCode: "1234567890",
        paidDate: DateTime.Now,
        expireDate: DateTime.Now,
        total: 0,
        totalPaid: 0,
        payer: "Angelo Evangelista",
        document,
        address
      );

      Assert.IsTrue(payment.Invalid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenTotalPaidIsLessThanTotal()
    {
      var email = new Email("this.is@valid.email");

      var document = new Document("12345678901", EDocumentType.CPF);

      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      var payment = new PayPalPayment(
        email,
        transactionCode: "1234567890",
        paidDate: DateTime.Now,
        expireDate: DateTime.Now,
        total: 100,
        totalPaid: 99,
        payer: "Angelo Evangelista",
        document,
        address
      );

      Assert.IsTrue(payment.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenTotaIsGreaterThanOrEqualsToTotalPaidAndGreaterThanZero()
    {
      var email = new Email("this.is@valid.email");

      var document = new Document("12345678901", EDocumentType.CPF);

      var address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      var payment = new PayPalPayment(
        email,
        transactionCode: "1234567890",
        paidDate: DateTime.Now,
        expireDate: DateTime.Now,
        total: 100,
        totalPaid: 100,
        payer: "Angelo Evangelista",
        document,
        address
      );

      Assert.IsTrue(payment.Valid);
    }
  }
}
