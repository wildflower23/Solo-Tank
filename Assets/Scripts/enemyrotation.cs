
using UnityEngine;

public class enemyrotation : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    private Vector3 targetDirection;
    private float rotationpostion;

    private void Update()
    {
          targetDirection = (enemy.GetComponent<RectTransform>().position-player.GetComponent<RectTransform>().position).normalized;
        rotationpostion = Mathf.Atan2(targetDirection.x, targetDirection.y) * Mathf.Rad2Deg;
        enemy.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0,270- rotationpostion);
        

    }
}
//enemy.GetComponent<RectTransform>().rotation