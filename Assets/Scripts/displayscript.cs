using UnityEngine;
using static gameManager;

public class DisplayScript : MonoBehaviour
{
    public GameObject displaypanel;

    public static DisplayScript Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void Pausebutton()
    {
        PauseScript.Instance.ShowPauseUI();
        gameManager.SetGameActivity(GameActivity.Pause);
    }
}
