using UnityEngine;

public class powerup : MonoBehaviour
{
    public Transform[] powerposition;
    public GameObject power;

    private float timer = 0;
    public float shootInterval = 15;

    void Start()
    {

    }
    public void shootrandom()
    {
        int randomno = Random.Range(0, powerposition.Length);
        Instantiate(power, powerposition[randomno].position, powerposition[randomno].rotation);
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
