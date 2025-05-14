using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform toFollow;  // The object the camera should follow

    [Header("Smoothing")]
    [SerializeField] private float smoothTimeX = 0.3f;  // Lower = faster follow on X
    [SerializeField] private float smoothTimeY = 0.3f;  // Lower = faster follow on Y

    [Header("Offset")]
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);  // Camera position offset

    [Header("Look-Ahead (Optional)")]
    [SerializeField] private float lookAheadFactor = 0f;  // How much the camera leads the target
    [SerializeField] private bool lookAheadOnlyWhenMoving = true;  // Only apply look-ahead if moving

    private float zPosition;  // Fixed Z position (for 2D)
    private float xVelocity, yVelocity;  // SmoothDamp velocity tracking

    private void Start()
    {
        if (toFollow == null)
        {
            Debug.LogError("FollowCamera: No target assigned!");
            enabled = false;
            return;
        }

        zPosition = transform.position.z;  // Lock the Z position
    }

    private void LateUpdate()
    {
        if (toFollow == null) return;

        // Calculate target position with offset
        Vector3 targetPosition = toFollow.position + offset;

        // Apply look-ahead if enabled
        if (lookAheadFactor > 0)
        {
            bool shouldLookAhead = !lookAheadOnlyWhenMoving || Mathf.Abs(xVelocity) > 0.1f;
            if (shouldLookAhead)
            {
                targetPosition.x += xVelocity * lookAheadFactor;
                targetPosition.y += yVelocity * lookAheadFactor;
            }
        }

        // Smoothly follow the target on X and Y axes
        float smoothedX = Mathf.SmoothDamp(
            transform.position.x,
            targetPosition.x,
            ref xVelocity,
            smoothTimeX
        );

        float smoothedY = Mathf.SmoothDamp(
            transform.position.y,
            targetPosition.y,
            ref yVelocity,
            smoothTimeY
        );

        // Apply the new position while keeping Z fixed
        transform.position = new Vector3(smoothedX, smoothedY, zPosition);
    }
}