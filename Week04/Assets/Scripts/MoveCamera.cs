using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float speed = 5;
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2 (x, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
