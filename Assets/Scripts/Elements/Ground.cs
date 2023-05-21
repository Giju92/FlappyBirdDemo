using UnityEngine;

public class Ground : BaseObserver
{
    [SerializeField]
    RectTransform groundToMove;

    private float _velocity;
    private float _maxPosition;

    private void Awake()
    {
        _maxPosition = groundToMove.sizeDelta.x;
        _velocity = GameConstant.HORIZONTAL_SPEED;
    }

    private void Update()
    {
        if (state_GAME)
        {
            groundToMove.localPosition += Time.deltaTime * _velocity * Vector3.left;

            if (groundToMove.localPosition.x + _maxPosition < 0)
            {
                groundToMove.localPosition = new Vector2(0, groundToMove.localPosition.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Notify(GameEventEnum.END);
        }
    }
}