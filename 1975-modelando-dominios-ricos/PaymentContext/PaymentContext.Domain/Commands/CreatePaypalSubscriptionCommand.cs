using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
  public class CreatePaypalSubscriptionCommand : Notifiable, ICommand
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Document { get; set; }
    public string TransactionCode { get; set; }
    public string PaymentNumber { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public string PayerDocument { get; set; }
    public EDocumentType PayerDocumentType { get; set; }
    public string PayerEmailAddress { get; set; }
    public string Street { get; set; }
    public string AddressNumber { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }

    public void Validate()
    {
      AddNotifications(new Contract()
        .Requires()
        .HasMinLen(FirstName, 3, "Name.FirstName", "O Nome deve conter ao menos 3 caracteres.")
        .HasMinLen(LastName, 3, "Name.LastName", "O Sobrenome deve conter ao menos 3 caracteres.")
        .HasMaxLen(FirstName, 40, "Name.FirstName", "O Nome deve ter até 40 caracteres.")
        .HasMaxLen(LastName, 40, "Name.LastName", "O Sobrenome deve ter até 40 caracteres.")
      );
    }
  }
}
