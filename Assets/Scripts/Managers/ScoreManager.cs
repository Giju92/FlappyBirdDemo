using UnityEngine;

public class ScoreManager : BaseObserver
{
    [SerializeField]
    Counter bestScore;

    [SerializeField]
    Counter gameScore;

    int _bestScore;
    int _currentScore;

    protected override void Initialize() 
    {
        base.Initialize();
        _bestScore = PlayerPrefs.GetInt("best_score", 0);
    }

    protected override void OnMainMenuEvent() 
    {
        base.OnMainMenuEvent();
        bestScore.SetNumber(_bestScore);
    }

    protected override void OnTutorialEvent() 
    {
        base.OnTutorialEvent();
        _currentScore = 0;
        gameScore.SetNumber(_currentScore);
    }
    
    protected override void OnObstaclePassedEvent() 
    {
        base.OnObstaclePassedEvent();
        _currentScore++;
        gameScore.SetNumber(_currentScore);
    }
    
    protected override void OnEndEvent() 
    {
        base.OnEndEvent();

        if(_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
            PlayerPrefs.SetInt("best_score", _bestScore);
        }
    }

}
