using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.ValueObjects
{
  public class Document : ValueObject
  {
    public Document(string number, EDocumentType type)
    {
      Number = number;
      Type = type;

      AddNotifications(new Contract()
        .Requires()
        .IsTrue(Validate(), "Document.Number", "Documento inválido.")
      );
    }

    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }

    private bool Validate()
    {
      switch (Type)
      {
        case EDocumentType.CPF:
          return Number.Length == 11;

        case EDocumentType.CNPJ:
          return Number.Length == 14;
      }

      return false;
    }
  }
}
