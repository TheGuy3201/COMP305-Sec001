using System.Collections;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] float amplitude = 4f;
    [SerializeField] float angleSpeed = 0.1f;
    [SerializeField] float waitTime = 0.02f;

    GameObject captureObject;
    float originX;
    float originY;
    float angle = 0f;

    private void Start()
    {
        originX = transform.position.x;
        originY = transform.position.y;
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            angle += angleSpeed;
            float deltaX = Mathf.Sin(angle) * amplitude;
            transform.position = new Vector2(originX + deltaX, originY);

            if (captureObject != null)
            {
                captureObject.transform.position = transform.position;
            }

            yield return new WaitForSeconds(waitTime);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform); 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null); 
        }
    }


}
