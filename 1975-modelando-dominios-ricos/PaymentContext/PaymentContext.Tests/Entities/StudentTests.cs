using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {
    private readonly Name _name;
    private readonly Email _email;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Payment _payment;


    public StudentTests()
    {
      _name = new Name("Angus", "MacGyver");
      _email = new Email("this.is@valid.email");
      _document = new Document("12345678901", EDocumentType.CPF);

      _address = new Address(
        street: "Street number three",
        number: "10000",
        neighborhood: "A pretty place",
        city: "Long Beach",
        state: "Boot lands",
        country: "United Status",
        zipCode: "12345"
      );

      _payment = new PayPalPayment(
        _email,
        transactionCode: "1234567890",
        paidDate: DateTime.Now,
        expireDate: DateTime.Now,
        total: 100,
        totalPaid: 100,
        payer: "Angelo Evangelista",
        _document,
        _address
      );
    }

    [TestMethod]
    public void ShouldReturnErrorWhenAddedSubscriptionHasNoPayments()
    {
      var student = new Student(_name, _document, _email);

      var subscription = new Subscription(DateTime.Now);

      student.AddSubscription(subscription);

      Assert.IsTrue(student.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddedSubscriptionHasPayment()
    {
      var student = new Student(_name, _document, _email);

      var subscription = new Subscription(DateTime.Now);
      subscription.AddPayment(_payment);

      student.AddSubscription(subscription);

      Assert.IsTrue(student.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenStudentHasAnActiveSubscription()
    {
      var student = new Student(_name, _document, _email);

      var subscriptionA = new Subscription(DateTime.Now);
      subscriptionA.AddPayment(_payment);

      var subscriptionB = new Subscription(DateTime.Now);
      subscriptionB.AddPayment(_payment);

      student.AddSubscription(subscriptionA);
      student.AddSubscription(subscriptionB);

      Assert.IsTrue(student.Invalid);
    }
  }
}
