using UnityEngine;

public class enemyshootscript : MonoBehaviour
{
    public GameObject bulletbrustparticle;

    public Transform[] firepoint;
    public GameObject bulletprefab;

    private float timer=0;
    public float shootInterval = 15;

    void Start()
    {
        
    }
    public void shootrandom()
    {
        var em= bulletbrustparticle.GetComponent<ParticleSystem>().emission;
        int randomno = Random.Range(0, firepoint.Length);
        if ((firepoint[randomno].parent.gameObject.activeSelf))
        {


            bulletbrustparticle.GetComponent<Transform>().position = firepoint[randomno].position;
            bulletbrustparticle.GetComponent<Transform>().rotation = firepoint[randomno].rotation;
            bulletbrustparticle.GetComponent<ParticleSystem>().Play();
            em.enabled = true;
            Instantiate(bulletprefab, firepoint[randomno].position, firepoint[randomno].rotation);
        }
    }


    void Update()
    {
        if (gameManager.gameActivity == gameManager.GameActivity.Playing)
        {
            if (timer < shootInterval)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {

                shootrandom();
                timer = 0;
            }
        }
    }
}
