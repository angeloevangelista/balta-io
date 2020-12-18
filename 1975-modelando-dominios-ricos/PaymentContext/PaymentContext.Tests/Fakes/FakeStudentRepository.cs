using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Fake
{
  public class FakeStudentRepository : IStudentRepository
  {
    private readonly IList<Student> _students;

    public FakeStudentRepository()
    {
      _students = new List<Student>();
    }

    public void CreateSubscription(Student student)
    {
    }

    public bool DocumentExists(string document)
    {
      if (document == "99999999999")
        return true;

      return false;

      // bool hasStudentWithDocument = _students
      //   .Any(pre => pre.Document.Number == document);

      // return hasStudentWithDocument;
    }

    public bool EmailExists(string email)
    {
      if (email == "this.is@valid.email")
        return true;

      return false;

      // bool hasStudentWithEmail = _students
      //   .Any(pre => pre.Email.Address == email);

      // return hasStudentWithEmail;
    }
  }
}
