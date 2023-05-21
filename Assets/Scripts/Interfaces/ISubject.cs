public interface ISubject
{
    public void NotifyObservers(GameEventEnum gameEvent);
    public void AddObserver(IObserver observer);
    public void RemoveObserver(IObserver observer);
}
