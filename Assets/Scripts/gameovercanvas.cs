using UnityEngine;
using DG.Tweening;
using System.Collections;
using static gameManager;
using UnityEngine.SceneManagement;
public class GameoverScript : MonoBehaviour
{
    
    public GameObject gameoverbgpanel;
    public GameObject gameoverpanel;

    public float duration = 0.25f;

    public static GameoverScript Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        gameoverbgpanel.GetComponent<CanvasGroup>().alpha = 0f;
        gameoverbgpanel.SetActive(false);
    }
    public void HomeButton()
    {
        CloseGameoverUI();
        HomeScript.Instance.ShowHomeUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameManager.SetGameActivity(GameActivity.Home);
    }
    public void ShowGameoverUI()
    {
        DOTween.To(() => gameoverbgpanel.GetComponent<CanvasGroup>().alpha, x => gameoverbgpanel.GetComponent<CanvasGroup>().alpha = x, 1, duration);
        StartCoroutine(setactive(gameoverbgpanel));
    }
    public void CloseGameoverUI()
    {
        DOTween.To(() => gameoverbgpanel.GetComponent<CanvasGroup>().alpha, x => gameoverbgpanel.GetComponent<CanvasGroup>().alpha = x, 0, duration);
        StartCoroutine(setactive(gameoverbgpanel));
    }
    IEnumerator setactive(GameObject panelname)
    {
        yield return new WaitForSeconds(duration);
        panelname.SetActive(!(panelname.activeSelf));
    }
}
