using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {
    [TestMethod]
    public void TestMethod1()
    {
      var subscription = new Subscription(expireDate: null);

      var name = new Name(firstName: "Angelo", lastName: "Evangelista");

      var document = new Document(
        number: "123456789",
        type: EDocumentType.CPF
      );

      var email = new Email("angeloevan.ane@gmail.com");

      var student = new Student(name, document, email);

      student.AddSubscription(subscription);
    }
  }
}
