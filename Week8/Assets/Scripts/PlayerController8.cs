using UnityEngine;

public class PlayerController8 : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(x, y);
        movement.Normalize();
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
