using UnityEngine;

public class firebtn : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform firepoint;
    public GameObject bulletbrustparticle;

    public static firebtn Instance;

    private void Awake()
    {

        Instance = this;
    }
    
    void Start()
    {
        
    }


     public void onfire()
    {
        var em = bulletbrustparticle.GetComponent<ParticleSystem>().emission;
        if (gameManager.gameActivity == gameManager.GameActivity.Playing)
        {
            bulletbrustparticle.GetComponent<Transform>().position = firepoint.position;
            bulletbrustparticle.GetComponent<Transform>().rotation = firepoint.rotation;
            bulletbrustparticle.GetComponent<ParticleSystem>().Play();
            em.enabled = true;
            Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
