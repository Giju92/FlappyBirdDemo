using UnityEngine;

public class GameManager : BaseObserver
{
    protected override void Initialize()
    {
        base.Initialize();
        Notify(GameEventEnum.MAIN_MENU);
    }

    public void OnClick()
    {
        if (state_MAIN_MENU)
        {
            Notify(GameEventEnum.TUTORIAL);
        }
        else
        if (state_TUTORIAL)
        {
            Notify(GameEventEnum.START_GAME);
        }
        else
        if (state_GAME)
        {
            Notify(GameEventEnum.TAP_IN_GAME);
        }
        else
        if (state_END)
        {
            Notify(GameEventEnum.MAIN_MENU);
        }
    }
}