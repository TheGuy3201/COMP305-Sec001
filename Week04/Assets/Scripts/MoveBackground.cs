using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] float parallaxSpeed; //lower the number, the faster the movement (1 is max)
    Transform cameraTransform;
    float startPosition;
    float spriteWidth;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        startPosition = transform.position.x;
        spriteWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x;

    }

    private void Update()
    {
        float relativeDistance = cameraTransform.position.x * parallaxSpeed;
        transform.position = new Vector3(startPosition + relativeDistance, 0, 0);

        float relativeCameraPosition = cameraTransform.position.x - relativeDistance;

        if (relativeCameraPosition > startPosition + spriteWidth)
        {
            startPosition += spriteWidth;
        }
        else if (relativeCameraPosition < startPosition - spriteWidth)
        {
            startPosition -= spriteWidth;
        }

    }
}
