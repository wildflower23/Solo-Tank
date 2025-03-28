using UnityEngine;




public class tanktopmovement : MonoBehaviour
{
    public FixedJoystick topjoystick;
    public GameObject tanktop;

    private float rotationpostion;
    private float lastposition;



    public float movespeed;

    private Vector2 movepostion;
    
    void Start()
    {
        tanktop.GetComponent<Transform>().position = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameActivity == gameManager.GameActivity.Playing)
        {
            
            if(topjoystick.Horizontal != 0 || topjoystick.Vertical != 0)
            {
                rotationpostion = Mathf.Atan2(topjoystick.Horizontal, topjoystick.Vertical) * Mathf.Rad2Deg;
                lastposition=rotationpostion;
                tanktop.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, rotationpostion);
            }
            else
            {
                tanktop.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, lastposition);
            }
            //movepostion = new Vector2(topjoystick.Horizontal, topjoystick.Vertical);
            //rotationpostion = Mathf.Atan2(topjoystick.Horizontal, topjoystick.Vertical) * Mathf.Rad2Deg;

            //tanktop.GetComponent<Transform>().rotation = Quaternion.FromToRotation(transform.position, movepostion);
            //tanktop.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, rotationpostion);
        }
    }
   
}
