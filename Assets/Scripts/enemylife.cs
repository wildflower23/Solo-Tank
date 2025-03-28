using DG.Tweening;
using System.Collections;
using UnityEngine;

public class enemylife : MonoBehaviour
{
    public GameObject smokeparticle;
    public GameObject fireparticle;

    public GameObject enemy;
    public GameObject firepoint;
    private int hitcounter=0;
    
    void Start()
    {
        hitcounter = 0;
    }
    IEnumerator activeenenmy()
    {
       
        yield return new WaitForSeconds(5f);
        DOTween.To(() => enemy.GetComponent<CanvasGroup>().alpha, x => enemy.GetComponent<CanvasGroup>().alpha = x, 1, 0.1f);
        firepoint.SetActive(true);
        hitcounter = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var fireem = fireparticle.GetComponent<ParticleSystem>().emission;
        var smokeem = smokeparticle.GetComponent<ParticleSystem>().emission;
        if (gameManager.gameActivity == gameManager.GameActivity.Playing)
        {
            if (collision.gameObject.name == "tankbullet(Clone)")
            {
                hitcounter++;
                if (hitcounter == 3)
                {
                    //particle
                    smokeparticle.GetComponent<Transform>().position = enemy.GetComponent<Transform>().position;
                    fireparticle.GetComponent<Transform>().position = enemy.GetComponent<Transform>().position;
                    fireparticle.GetComponent<ParticleSystem>().Play();
                    fireem.enabled = true;
                    smokeparticle.GetComponent<ParticleSystem>().Play();
                    smokeem.enabled = true;
                    //gameObject.SetActive(false);
                    DOTween.To(() => enemy.GetComponent<CanvasGroup>().alpha, x => enemy.GetComponent<CanvasGroup>().alpha = x, 0, 0.1f);
                    firepoint.SetActive(false);
                    StartCoroutine(activeenenmy());

                    hitcounter = 0;
                }
                
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name == "bullet(Clone)")
            {
                Destroy(collision.gameObject);
            }
            }
    }
}
