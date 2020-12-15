using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {
    [TestMethod]
    public void TestMethod1()
    {
      var subscription = new Subscription(expireDate: null);

      var student = new Student(
        firstName: "Angelo",
        lastName: "Evangelista",
        document: "123456789",
        email: "angeloevan.ane@gmail.com"
      );

      student.AddSubscription(subscription);


    }
  }
}
