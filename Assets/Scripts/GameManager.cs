using UnityEngine;

public class gameManager
{
    public enum GameActivity { Home, Playing, Pause, GameOver, Setting }
    public static GameActivity gameActivity = GameActivity.Home;

    public static void SetGameActivity(GameActivity setActivity)
    {
        gameActivity = setActivity;
    }
}

