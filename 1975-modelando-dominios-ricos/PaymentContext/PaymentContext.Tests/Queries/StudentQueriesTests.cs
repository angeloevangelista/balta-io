using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
  [TestClass]
  public class StudentQueriesTests
  {
    private readonly IList<Student> _students;

    public StudentQueriesTests()
    {
      _students = new List<Student>();

      for (int i = 0; i < 10; i++)
        _students.Add(new Student(
          name: new Name(
            firstName: "Angelo",
            lastName: i.ToString()
          ),
          document: new Document($"9999999999{i}", EDocumentType.CPF),
          email: new Email($"this.is_{i}@valid.email")
        ));
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentDoesNotExist()
    {
      var expression = StudentQueries.GetStudentInformation("12345678901");
      var student = _students.AsQueryable().Where(expression).FirstOrDefault();

      Assert.AreEqual(null, student);
    }

    [TestMethod]
    public void ShouldReturnAStudentWhenDocumentExist()
    {
      var expression = StudentQueries.GetStudentInformation("99999999999");
      var student = _students.AsQueryable().Where(expression).FirstOrDefault();

      Assert.AreNotEqual(null, student);
    }
  }
}
