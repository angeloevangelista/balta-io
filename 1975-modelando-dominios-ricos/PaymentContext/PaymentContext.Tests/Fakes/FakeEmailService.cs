using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;

namespace PaymentContext.Tests.Fake
{
  public class FakeEmailService : IEmailService
  {
    public void Send(string to, string email, string subject, string body)
    {
      Thread.Sleep(1000);
    }
  }
}
