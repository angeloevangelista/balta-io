using Flunt.Notifications;

namespace PaymentContext.Shared.Commands
{
  public abstract class Command : Notifiable, ICommand
  {
    public virtual void Validate() { }
  }
}
