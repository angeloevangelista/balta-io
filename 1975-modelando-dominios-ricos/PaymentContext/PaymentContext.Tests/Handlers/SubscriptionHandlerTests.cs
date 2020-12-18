using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Fake;

namespace PaymentContext.Tests.Handlers
{
  [TestClass]
  public class SubscriptionHandlerTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
      var subscriptionHandler = new SubscriptionHandler(
        new FakeStudentRepository(),
        new FakeEmailService()
      );

      var command = new CreateBoletoSubscriptionCommand
      {
        FirstName = "Angelo",
        LastName = "Evangelista",
        EmailAddress = "angeloevan.ane@gmail.com",
        Document = "99999999999",
        BarCode = "123456789",
        BoletoNumber = "123456789",
        PaymentNumber = "123456789",
        PaidDate = DateTime.Now,
        ExpireDate = DateTime.Now.AddMonths(1),
        Total = 100,
        TotalPaid = 100,
        Payer = "Angelo Evangelista",
        PayerDocument = "11111111111",
        PayerDocumentType = EDocumentType.CPF,
        PayerEmailAddress = "angeloevan.ane@gmail.com",
        Street = "Av. Hue",
        AddressNumber = "1000",
        Neighborhood = "Place Three",
        City = "Long Beach",
        State = "Alive Land",
        Country = "Brazil",
        ZipCode = "12345",
      };

      subscriptionHandler.Handle(command);

      Assert.IsTrue(subscriptionHandler.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenDocumentDoesNotExist()
    {
      var subscriptionHandler = new SubscriptionHandler(
        new FakeStudentRepository(),
        new FakeEmailService()
      );

      var command = new CreateBoletoSubscriptionCommand
      {
        FirstName = "Angelo",
        LastName = "Evangelista",
        EmailAddress = "angeloevan.ane@gmail.com",
        Document = "11111111111",
        BarCode = "123456789",
        BoletoNumber = "123456789",
        PaymentNumber = "123456789",
        PaidDate = DateTime.Now.AddDays(5),
        ExpireDate = DateTime.Now.AddMonths(1),
        Total = 100,
        TotalPaid = 100,
        Payer = "Angelo Evangelista",
        PayerDocument = "11111111111",
        PayerDocumentType = EDocumentType.CPF,
        PayerEmailAddress = "angeloevan.ane@gmail.com",
        Street = "Av. Hue",
        AddressNumber = "1000",
        Neighborhood = "Place Three",
        City = "Long Beach",
        State = "Alive Land",
        Country = "Brazil",
        ZipCode = "12345",
      };

      subscriptionHandler.Handle(command);

      Assert.IsTrue(subscriptionHandler.Valid);
    }
  }
}
