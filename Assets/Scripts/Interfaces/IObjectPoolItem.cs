public interface IObjectPoolItem
{
    public void ReturnToPool();
    public void SetPool(IObjectPool pool);
    public void Reset();
}
