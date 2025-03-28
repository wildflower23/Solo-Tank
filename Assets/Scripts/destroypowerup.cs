using UnityEngine;
using System.Collections;
public class destroypowerup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(destroygameobject());
        }
    }
    IEnumerator destroygameobject()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
