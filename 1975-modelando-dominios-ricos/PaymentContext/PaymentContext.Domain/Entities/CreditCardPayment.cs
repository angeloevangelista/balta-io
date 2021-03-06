using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
  public class CreditCardPayment : Payment
  {
    public CreditCardPayment(
      string cardHolderName,
      string finalCardNumbers,
      DateTime paidDate,
      DateTime expireDate,
      decimal total,
      decimal totalPaid,
      string payer,
      Document document,
      Address address
    ) : base(paidDate, expireDate, total, totalPaid, payer, document, address)
    {
      CardHolderName = cardHolderName;
      FinalCardNumbers = finalCardNumbers;
    }

    public string CardHolderName { get; private set; }
    public string FinalCardNumbers { get; private set; }
    public string LastTransactionNumber { get; private set; }
  }
}
