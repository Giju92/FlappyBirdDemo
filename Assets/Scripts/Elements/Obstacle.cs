using UnityEngine;

public class Obstacle : BaseObjectPoolItem
{
    private float _velocity;
    
    public void ResetPositionWithVerticalDisplacement(float displacement) 
    {
        transform.localPosition = new Vector3(0,displacement,0);
        transform.localScale = Vector3.one;
    }

    void Awake()
    {
        _velocity = GameConstant.HORIZONTAL_SPEED;
    }

    void Update()
    {
        if (_enabled)
        {
            transform.localPosition += Time.deltaTime * _velocity * Vector3.left;

            if (transform.localPosition.x + 2*Screen.width < 0)
                ReturnToPool();
        }
    }

    protected override void OnMainMenuEvent()
    {
        base.OnMainMenuEvent();
        ReturnToPool();
    }

    protected override void OnEndEvent() 
    {
        base.OnEndEvent();
        _enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Notify(GameEventEnum.END);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Notify(GameEventEnum.OBSTACLE_PASSED);
        }
    }
}
