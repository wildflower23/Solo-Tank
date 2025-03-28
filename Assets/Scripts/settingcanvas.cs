using UnityEngine;
using DG.Tweening;
using System.Collections;
using System;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    public static SettingScript Instance;
    public GameObject settingbgpanel;
    public GameObject settingpanel;

    private float duration = 0.25f;
    private float distance = 86f;

    [Header("Toggle----")]
    public Image bgtoggle;
    public Image sfxtoggle;
    [HideInInspector]
    public bool isBackgroundSoundon;
    public bool isSFXSoundOn;

    public AudioSource bgclip;
    public AudioSource sfxclip;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

        settingpanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        settingbgpanel.GetComponent<CanvasGroup>().alpha = 0f;
        settingbgpanel.SetActive(false);
        bgclip = gameObject.AddComponent<AudioSource>();
        sfxclip = gameObject.AddComponent<AudioSource>();
        bgclip.clip = (AudioClip)Resources.Load("Audio/background");
        bgclip.loop = true;
       // isSFXSoundOn = Convert.ToBoolean(PlayerPrefs.GetString("isotherOn"));
        CheckbackgroundSound();
    }
    public void Onbgtogglemove()
    {
        isBackgroundSoundon = !isBackgroundSoundon;
        if (isBackgroundSoundon)
        {
            movetoggleright(bgtoggle, distance);
            //PlayerPrefs.SetString("isON", "true");
            bgclip.Play();
        }
        else
        {
            movetoggleleft(bgtoggle, -distance);
            //PlayerPrefs.SetString("isON", "false");
            bgclip.Stop();
        }
    }
    public void Onsfxtogglemove()
    {
        isSFXSoundOn = !isSFXSoundOn;
        if (isSFXSoundOn)
        {
            movetoggleright(sfxtoggle, distance);
            //PlayerPrefs.SetString("isotherOn", "true");
        }
        else
        {
            movetoggleright(sfxtoggle, -distance);
            //PlayerPrefs.SetString("isotherOn", "false");
            sfxclip.Stop();
        }
    }

    public void CheckbackgroundSound()
    {
        //isBackgroundSoundon = Convert.ToBoolean(PlayerPrefs.GetString("isON"));
        
        if (isBackgroundSoundon)
        {
            movetoggleright(bgtoggle, distance);
            //PlayerPrefs.SetString("isON", "true");
            bgclip.Play();
        }
        else
        {
            movetoggleleft(bgtoggle, -distance);
            //PlayerPrefs.SetString("isON", "false");
            bgclip.Stop();
        }
    }

    public void movetoggleright(Image toggle, float distance)
    {
        toggle.transform.DOLocalMoveX(distance, 0.2f);

    }
    public void movetoggleleft(Image toggle, float distance)
    {
        toggle.transform.DOLocalMoveX(distance, 0.2f);

    }
    public void ShowSettingUI()
    {
       
        DOTween.To(() => settingbgpanel.GetComponent<CanvasGroup>().alpha, x => settingbgpanel.GetComponent<CanvasGroup>().alpha = x, 1, duration);
        StartCoroutine(setactive(settingbgpanel));
        settingpanel.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), duration);
        
        
    }

    public void CloseSettingUI()
    {
        settingpanel.GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), duration);
        DOTween.To(() => settingbgpanel.GetComponent<CanvasGroup>().alpha, x => settingbgpanel.GetComponent<CanvasGroup>().alpha = x, 0, duration);
        StartCoroutine(setactive(settingbgpanel));
        if (gameManager.gameActivity == gameManager.GameActivity.Pause)
        {
            PauseScript.Instance.ShowPauseUI();
        }
        else
        {
            HomeScript.Instance.ShowHomeUI();
        }
        CheckbackgroundSound();
    }

   
    IEnumerator setactive(GameObject panelname)
    {

        yield return new WaitForSeconds(duration);
        panelname.SetActive(!(panelname.activeSelf));

    }

    public void BulletHitSound()
    {
        if (isSFXSoundOn)
        {
            sfxclip.clip = Resources.Load<AudioClip>("Audio/bullethit");
            sfxclip.Play();
        }

    }
}
