using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(x,y);
        movement.Normalize();
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
