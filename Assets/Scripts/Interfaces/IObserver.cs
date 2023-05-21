public interface IObserver 
{
    public void OnNotify(GameEventEnum gameEvent);
    public void Notify(GameEventEnum gameEvent);
    
}
