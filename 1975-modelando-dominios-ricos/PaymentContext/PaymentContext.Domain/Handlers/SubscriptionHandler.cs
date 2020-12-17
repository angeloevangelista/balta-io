using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
  public class SubscriptionHandler :
    Notifiable,
    IHandler<CreateBoletoSubscriptionCommand>,
    IHandler<CreatePaypalSubscriptionCommand>,
    IHandler<CreateCreditCardSubscriptionCommand>
  {
    private readonly IStudentRepository _studentRepository;
    private readonly IEmailService _emailService;
    private readonly CommandResult _failCommandResult;

    public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
    {
      _studentRepository = studentRepository;
      _emailService = emailService;
      _failCommandResult = new CommandResult(false, "Não foi possível realizar sua assinatura.");
    }

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
      // Fail Fast Validations
      command.Validate();
      AddNotifications(command);

      if (command.Invalid)
        return _failCommandResult;

      // Verificar se o documento já está cadastrado
      if (_studentRepository.DocumentExists(command.Document))
      {
        AddNotification("Document", "Este documento já está em uso.");
        return _failCommandResult;
      }

      // Verificar se o E-mail já está cadastrado
      if (_studentRepository.DocumentExists(command.EmailAddress))
      {
        AddNotification("EmailAddress", "Este E-mail já está em uso.");
        return _failCommandResult;
      }

      // Gerar VOs
      var name = new Name(command.FirstName, command.LastName);
      var email = new Email(command.EmailAddress);
      var document = new Document(command.Document, EDocumentType.CPF);

      var address = new Address(
        street: command.Street,
        number: command.AddressNumber,
        neighborhood: command.Neighborhood,
        city: command.City,
        state: command.State,
        country: command.Country,
        zipCode: command.ZipCode
      );

      var payerDocument = new Document(
        command.PayerDocument,
        command.PayerDocumentType
      );

      // Gerar as entidades
      var student = new Student(name, document, email);

      var subscription = new Subscription(DateTime.Now.AddMonths(1));

      var payment = new BoletoPayment(
        barCode: command.BarCode,
        boletoNumber: command.BoletoNumber,
        email: command.PayerEmailAddress,
        paidDate: command.PaidDate,
        expireDate: command.ExpireDate,
        total: command.Total,
        totalPaid: command.TotalPaid,
        payer: command.Payer,
        document: payerDocument,
        address
      );

      // Relacionamentos
      subscription.AddPayment(payment);
      student.AddSubscription(subscription);

      // Agrupar as validações
      AddNotifications(
        name,
        document,
        email,
        address,
        student,
        subscription,
        payment
      );

      // Verificar antes de salvar
      if (this.Invalid)
        return _failCommandResult;

      // Salvar as informações
      _studentRepository.CreateSubscription(student);

      // Enviar E-mail de boas vindas
      _emailService.Send(
        to: student.Name.ToString(),
        email: student.Email.Address,
        subject: "Bem vindo ao balta.io.",
        body: "Sua assinatura foi realizada."
      );

      // Retornar informações
      return new CommandResult(true, "Assinatura realizada com sucesso.");
    }

    public ICommandResult Handle(CreatePaypalSubscriptionCommand command)
    {
      // Fail Fast Validations
      command.Validate();
      AddNotifications(command);

      if (command.Invalid)
        return _failCommandResult;

      // Verificar se o documento já está cadastrado
      if (_studentRepository.DocumentExists(command.Document))
      {
        AddNotification("Document", "Este documento já está em uso.");
        return _failCommandResult;
      }

      // Verificar se o E-mail já está cadastrado
      if (_studentRepository.DocumentExists(command.EmailAddress))
      {
        AddNotification("EmailAddress", "Este E-mail já está em uso.");
        return _failCommandResult;
      }

      // Gerar VOs
      var name = new Name(command.FirstName, command.LastName);
      var email = new Email(command.EmailAddress);
      var document = new Document(command.Document, EDocumentType.CPF);

      var address = new Address(
        street: command.Street,
        number: command.AddressNumber,
        neighborhood: command.Neighborhood,
        city: command.City,
        state: command.State,
        country: command.Country,
        zipCode: command.ZipCode
      );

      var payerDocument = new Document(
        command.PayerDocument,
        command.PayerDocumentType
      );

      // Gerar as entidades
      var student = new Student(name, document, email);

      var subscription = new Subscription(DateTime.Now.AddMonths(1));

      var payment = new PayPalPayment(
        email: email,
        transactionCode: command.TransactionCode,
        paidDate: command.PaidDate,
        expireDate: command.ExpireDate,
        total: command.Total,
        totalPaid: command.TotalPaid,
        payer: command.Payer,
        document: document,
        address: address
      );

      // Relacionamentos
      subscription.AddPayment(payment);
      student.AddSubscription(subscription);

      // Agrupar as validações
      AddNotifications(
        name,
        document,
        email,
        address,
        student,
        subscription,
        payment
      );

      // Verificar antes de salvar
      if (this.Invalid)
        return _failCommandResult;

      // Salvar as informações
      _studentRepository.CreateSubscription(student);

      // Enviar E-mail de boas vindas
      _emailService.Send(
        to: student.Name.ToString(),
        email: student.Email.Address,
        subject: "Bem vindo ao balta.io.",
        body: "Sua assinatura foi realizada."
      );

      // Retornar informações
      return new CommandResult(true, "Assinatura realizada com sucesso.");
    }

    public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
    {
      // Fail Fast Validations
      command.Validate();
      AddNotifications(command);

      if (command.Invalid)
        return _failCommandResult;

      // Verificar se o documento já está cadastrado
      if (_studentRepository.DocumentExists(command.Document))
      {
        AddNotification("Document", "Este documento já está em uso.");
        return _failCommandResult;
      }

      // Verificar se o E-mail já está cadastrado
      if (_studentRepository.DocumentExists(command.EmailAddress))
      {
        AddNotification("EmailAddress", "Este E-mail já está em uso.");
        return _failCommandResult;
      }

      // Gerar VOs
      var name = new Name(command.FirstName, command.LastName);
      var email = new Email(command.EmailAddress);
      var document = new Document(command.Document, EDocumentType.CPF);

      var address = new Address(
        street: command.Street,
        number: command.AddressNumber,
        neighborhood: command.Neighborhood,
        city: command.City,
        state: command.State,
        country: command.Country,
        zipCode: command.ZipCode
      );

      var payerDocument = new Document(
        command.PayerDocument,
        command.PayerDocumentType
      );

      // Gerar as entidades
      var student = new Student(name, document, email);

      var subscription = new Subscription(DateTime.Now.AddMonths(1));

      var payment = new CreditCardPayment(
        cardHolderName: command.CardHolderName,
        finalCardNumbers: command.FinalCardNumbers,
        paidDate: command.PaidDate,
        expireDate: command.ExpireDate,
        total: command.Total,
        totalPaid: command.TotalPaid,
        payer: command.Payer,
        document: document,
        address: address
      );

      // Relacionamentos
      subscription.AddPayment(payment);
      student.AddSubscription(subscription);

      // Agrupar as validações
      AddNotifications(
        name,
        document,
        email,
        address,
        student,
        subscription,
        payment
      );

      // Verificar antes de salvar
      if (this.Invalid)
        return _failCommandResult;

      // Salvar as informações
      _studentRepository.CreateSubscription(student);

      // Enviar E-mail de boas vindas
      _emailService.Send(
        to: student.Name.ToString(),
        email: student.Email.Address,
        subject: "Bem vindo ao balta.io.",
        body: "Sua assinatura foi realizada."
      );

      // Retornar informações
      return new CommandResult(true, "Assinatura realizada com sucesso.");
    }
  }
}
