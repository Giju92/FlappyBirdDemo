using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class FlappyBird : BaseObserver
{
    Animator an;
    Rigidbody2D rb;
    AudioSource audioSource;

    private float velocity = 1;

    protected override void Initialize()
    {
        base.Initialize();
        velocity = GameConstant.VERTICAL_SPEED;

        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }

    protected override void OnStartEvent()
    {
        base.OnStartEvent();
        an.SetTrigger("Start");
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    protected override void OnEndEvent()
    {
        base.OnEndEvent();
        an.SetTrigger("Stop");
        rb.bodyType = RigidbodyType2D.Static;
    }

    protected override void OnTutorialEvent()
    {
        base.OnTutorialEvent();
        transform.localPosition = new Vector2(transform.localPosition.x, 0);
    }

    protected override void OnTapInGameEvent()
    {
        base.OnTapInGameEvent();
        rb.velocity = Vector2.up * velocity;
        audioSource.Play();
    }
}
