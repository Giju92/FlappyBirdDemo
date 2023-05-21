/// <summary>
/// Its duty is to ensure all the others managers are created
/// and is the "Subject" in a Observer pattern environment 
/// </summary>
public class ApplicationController : BaseSingleton<ApplicationController>
{
    BaseSubject subject;
    public BaseSubject Notifier { get { return subject; } }

    private void Awake()
    {
        SetInstance(this);
        subject = gameObject.AddComponent<BaseSubject>();
    }

    private void Start()
    {
        subject.NotifyObservers(GameEventEnum.MAIN_MENU);
    }

}
