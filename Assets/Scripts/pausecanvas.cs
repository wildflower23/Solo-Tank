using UnityEngine;
using DG.Tweening;
using System.Collections;
using static gameManager;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pausebgpanel;
    public GameObject pausepanel;

    public float duration = 0.25f;

    public static PauseScript Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        pausepanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        pausebgpanel.GetComponent<CanvasGroup>().alpha = 0f;
        pausebgpanel.SetActive(false);
    }
    public void HomeButton()
    {
        ClosePauseUI();
        HomeScript.Instance.ShowHomeUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameManager.SetGameActivity(GameActivity.Home);
        
    }
    public void SettingButton()
    {
        ClosePauseUI();
        SettingScript.Instance.ShowSettingUI();
        gameManager.SetGameActivity(GameActivity.Pause);
    }
    public void ResumeButton()
    {
        ClosePauseUI();
        gameManager.SetGameActivity(GameActivity.Playing);
    }
    public void ShowPauseUI()
    {
        
        DOTween.To(() => pausebgpanel.GetComponent<CanvasGroup>().alpha, x => pausebgpanel.GetComponent<CanvasGroup>().alpha = x, 1, duration);
        StartCoroutine(setactive(pausebgpanel));
        pausepanel.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), duration);
    }
    public void ClosePauseUI()
    {
        pausepanel.GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), 1f);
        DOTween.To(() => pausebgpanel.GetComponent<CanvasGroup>().alpha, x => pausebgpanel.GetComponent<CanvasGroup>().alpha = x, 0, duration);
        StartCoroutine(setactive(pausebgpanel));
        
    }
    IEnumerator setactive(GameObject panelname)
    {
        yield return new WaitForSeconds(duration);
        panelname.SetActive(!(panelname.activeSelf));
    }
}
