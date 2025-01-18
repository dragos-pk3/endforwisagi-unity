
public class NotifyObserversCommand : ICommand
{
    private ISubject _subject;

    public NotifyObserversCommand(ISubject subject)
    {
        _subject = subject;
    }

    public void Execute()
    {
        _subject.Notify();

    }
}