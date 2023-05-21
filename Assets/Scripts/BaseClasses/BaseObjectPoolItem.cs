using UnityEngine;

public class BaseObjectPoolItem : BaseObserver, IObjectPoolItem
{
    
    public bool _enabled;
    IObjectPool pool;

    public void SetPool(IObjectPool p)
    {
        pool = p;
    }

    public void ReturnToPool()
    {
        pool.Return(this);
    }

    public void Enable()
    {
        _enabled = true;
    }

    public void Reset() 
    {
        _enabled = false;
        transform.localPosition = new Vector3(Screen.width * 3, 0);
    }

}
