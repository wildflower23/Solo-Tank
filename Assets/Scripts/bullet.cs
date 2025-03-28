using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public GameObject bulletprefab;
    private Camera _camera;
    public Rigidbody2D rb;

    private void Awake()
    {
        _camera = Camera.main;
    }
    void Start()
    {
        rb.linearVelocity= transform.right*speed;
    }

    // Update is called once per frame
    void Update()
    {
        destroybulletoffscreen();


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collied");
        //if (collision.gameObject.name =="enemy1" || collision.gameObject.name == "enemy2" || collision.gameObject.name == "enemy3" || collision.gameObject.name == "tankbottom" )
        //{
        //    Destroy(this.gameObject);

        //}

    }
    private void destroybulletoffscreen()
    {
        Vector2 screenposition= _camera.WorldToScreenPoint(transform.position);

        if(screenposition.x < 0 ||
            screenposition.x > _camera.pixelWidth ||
            screenposition.y < 0 ||
            screenposition.y > _camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
