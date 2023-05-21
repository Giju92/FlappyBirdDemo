using UnityEngine;

public class UIManager : BaseObserver
{
    [SerializeField]
    CanvasGroup main_menu;

    [SerializeField]
    CanvasGroup tutorial;

    [SerializeField]
    CanvasGroup gameOver;

    protected override void OnMainMenuEvent()
    {
        base.OnMainMenuEvent();
        main_menu.alpha = 1;
        tutorial.alpha = 0;
        gameOver.alpha = 0;
    }

    protected override void OnTutorialEvent()
    {
        base .OnTutorialEvent();
        main_menu.alpha = 0;
        tutorial.alpha = 1;
        gameOver.alpha = 0;
    }
    
    protected override void OnStartEvent()
    {
        base.OnEndEvent();
        gameOver.alpha = 0;
        tutorial.alpha = 0;
        main_menu.alpha = 0;
    }

    protected override void OnEndEvent()
    {
        base.OnEndEvent();
        main_menu.alpha = 0;
        tutorial.alpha = 0;
        gameOver.alpha = 1;

    }
}