using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class SubscriptionTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenPaidDateIsInThePast()
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
        paidDate: new DateTime(1900, 1, 1),
        expireDate: DateTime.Now,
        total: 100,
        totalPaid: 100,
        payer: "Angelo Evangelista",
        document,
        address
      );

      var subscription = new Subscription(DateTime.Now.AddMonths(1));

      subscription.AddPayment(payment);

      Assert.IsTrue(subscription.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenPaidDateIsInTheFuture()
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
        paidDate: DateTime.Now.AddDays(3),
        expireDate: DateTime.Now,
        total: 100,
        totalPaid: 100,
        payer: "Angelo Evangelista",
        document,
        address
      );

      var subscription = new Subscription(DateTime.Now.AddMonths(1));

      subscription.AddPayment(payment);

      Assert.IsTrue(subscription.Valid);
    }
  }
}
