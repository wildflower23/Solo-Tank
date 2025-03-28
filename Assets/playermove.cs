using UnityEngine;

using System.Collections;
using UnityEngine.UI;
using DG.Tweening;



public class playermove : MonoBehaviour
{
    public GameObject smokeparticle;
    public GameObject fireparticle;
    public GameObject bulletbrustparticle;

    public FixedJoystick joystick;
    public GameObject tank;

    public Sprite[] lifeimage;
    public GameObject playerlifedisplay;

    private int lifedisplaycounter = 0;
    private int hitcounter = 0;

    public float movespeed;

    private Vector2 movepostion;
    private float rotationpostion;
    private float lastposition;
   
    private Camera _camera;

    private void Awake()
    {
         _camera = Camera.main;
    }
    void Start()
    {

        tank.GetComponent<Transform>().position=transform.position;
        lifedisplaycounter = 0;
        playerlifedisplay.GetComponent<Image>().sprite = lifeimage[lifedisplaycounter];
      
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScript.Instance.displaypanel.SetActive(false);

        if (gameManager.gameActivity == gameManager.GameActivity.Playing)
        {
            

          //tank move
            movepostion += new Vector2(joystick.Horizontal, joystick.Vertical) * movespeed * Time.deltaTime;
            //tank.GetComponent<Transform>().position = movepostion;
            tank.GetComponent<RectTransform>().position = movepostion;
         
            //tank rotation
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                rotationpostion = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg;
                lastposition = rotationpostion;
               // tank.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, rotationpostion);
                tank.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, rotationpostion);
            }
            else
            {
                //tank.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, lastposition);
                tank.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, lastposition);
            }
            //bullet on key down
            var em = bulletbrustparticle.GetComponent<ParticleSystem>().emission;
            if (Input.GetKeyDown(KeyCode.W))
            {
                bulletbrustparticle.GetComponent<Transform>().position = firebtn.Instance.firepoint.position;
                bulletbrustparticle.GetComponent<Transform>().rotation = firebtn.Instance.firepoint.rotation;
                bulletbrustparticle.GetComponent<ParticleSystem>().Play();
                em.enabled = true;
                firebtn.Instance.onfire();

            }
            DisplayScript.Instance.displaypanel.SetActive(true);
        }
           
    }
    private void FixedUpdate()
    {
        

        // Clamp within the screen bounds
        Vector2 leftEdge = _camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        movepostion.x = Mathf.Clamp(movepostion.x, leftEdge.x + 1.5f, rightEdge.x - 1.5f);
        movepostion.y = Mathf.Clamp(movepostion.y, leftEdge.y + 1.5f, rightEdge.y - 1.5f);
       
        tank.GetComponent<RectTransform>().position = movepostion;
       // tank.GetComponent<Transform>().position = movepostion;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var fireem=fireparticle.GetComponent<ParticleSystem>().emission;
        var smokeem=smokeparticle.GetComponent<ParticleSystem>().emission;
        if (gameManager.gameActivity == gameManager.GameActivity.Playing)
        {
            if (collision.gameObject.name == "bullet(Clone)")
            {
                hitcounter++;
                SettingScript.Instance.BulletHitSound();
                if (hitcounter == 2)
                {
                    hitcounter = 0;
                    lifedisplaycounter++;
                    if (lifedisplaycounter == 5)
                    {
                        playerlifedisplay.GetComponent<Image>().sprite = lifeimage[5];
                        //particlesystem
                        smokeparticle.GetComponent<Transform>().position = tank.GetComponent<Transform>().position;
                        fireparticle.GetComponent<Transform>().position = tank.GetComponent<Transform>().position;
                        fireparticle.GetComponent<ParticleSystem>().Play();
                        fireem.enabled = true;
                        smokeparticle.GetComponent<ParticleSystem>().Play();
                        smokeem.enabled = true;
                        StartCoroutine(gameover());
                        //DOTween.To(() => gameObject.GetComponent<CanvasGroup>().alpha, x => gameObject.GetComponent<CanvasGroup>().alpha = x, 0, 0.1f);
                        //gameObject.SetActive(false);
                        //gameover
                        
                        
                        gameManager.SetGameActivity(gameManager.GameActivity.GameOver);
                    }
                    else
                    {
                        playerlifedisplay.GetComponent<Image>().sprite = lifeimage[lifedisplaycounter];
                    }
                }


                Destroy(collision.gameObject);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "powerup(Clone)")
        {
            if (lifedisplaycounter > 0)
            {
                lifedisplaycounter--;
                playerlifedisplay.GetComponent<Image>().sprite = lifeimage[lifedisplaycounter];
            }
       
            Destroy(collision.gameObject);
        }

    }
     
   
    IEnumerator gameover()
    {
        yield return new WaitForSeconds(0.25f);
        GameoverScript.Instance.ShowGameoverUI();
        tank.SetActive(false);
    }
}
