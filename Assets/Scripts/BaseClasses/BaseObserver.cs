using UnityEngine;

public abstract class BaseObserver : MonoBehaviour, IObserver
{
    static ISubject subject => ApplicationController.GetInstance()?.Notifier;

    protected bool state_MAIN_MENU;
    protected bool state_TUTORIAL;
    protected bool state_GAME;
    protected bool state_END;

    void Start()
    {
        subject.AddObserver(this);
        Initialize();
    }

    void OnDisable()
    {
        subject?.RemoveObserver(this);
    }

    public void Notify(GameEventEnum gameEvent)
    {
        subject.NotifyObservers(gameEvent);
    }

    protected virtual void Initialize() 
    {
    }

    protected virtual void OnMainMenuEvent() { }
    protected virtual void OnTutorialEvent() { }
    protected virtual void OnStartEvent() { }
    protected virtual void OnObstaclePassedEvent() { }
    protected virtual void OnTapInGameEvent() { }
    protected virtual void OnEndEvent() { }

    public void OnNotify(GameEventEnum gameEvent)
    {
        switch (gameEvent)
        {
            case GameEventEnum.MAIN_MENU:
                state_MAIN_MENU = true;
                state_TUTORIAL = false;
                state_GAME = false;
                state_END = false;
                OnMainMenuEvent();
                break;
            case GameEventEnum.TUTORIAL:
                state_MAIN_MENU = false;
                state_TUTORIAL = true;
                state_GAME = false;
                state_END = false;
                OnTutorialEvent();
                break;
            case GameEventEnum.START_GAME:
                state_MAIN_MENU = false;
                state_TUTORIAL = false;
                state_GAME = true;
                state_END = false;
                OnStartEvent();
                break;
            case GameEventEnum.TAP_IN_GAME:
                OnTapInGameEvent();
                break;
            case GameEventEnum.OBSTACLE_PASSED:
                OnObstaclePassedEvent();
                break;
            case GameEventEnum.END:
                state_MAIN_MENU = false;
                state_TUTORIAL = false;
                state_GAME = false;
                state_END = true;
                OnEndEvent();
                break;
        }
    }
        
}
