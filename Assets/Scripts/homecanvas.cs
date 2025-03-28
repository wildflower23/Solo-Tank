using UnityEngine;
using DG.Tweening;
using System.Collections;
using static gameManager;
public class HomeScript : MonoBehaviour
{
    public GameObject homebgpanel;
    public GameObject homepanel;

    public float duration = 0.25f;

    public static HomeScript Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void onplaybtn()
    {
       CloseHomeUI();
        gameManager.SetGameActivity(GameActivity.Playing);
    }
    public void onsettingbtn()
    {
        CloseHomeUI();
        SettingScript.Instance.ShowSettingUI();
    }
    public void ShowHomeUI()
    {
        
        DOTween.To(() => homebgpanel.GetComponent<CanvasGroup>().alpha, x => homebgpanel.GetComponent<CanvasGroup>().alpha = x, 1, duration);
        StartCoroutine(setactive(homebgpanel));
        
    }
    public void CloseHomeUI()
    { 
        DOTween.To(() => homebgpanel.GetComponent<CanvasGroup>().alpha, x => homebgpanel.GetComponent<CanvasGroup>().alpha = x, 0, duration);
        StartCoroutine(setactive(homebgpanel));
        
    }
    IEnumerator setactive(GameObject panelname)
    {
        yield return new WaitForSeconds(duration);
        panelname.SetActive(!(panelname.activeSelf));
    }
}
