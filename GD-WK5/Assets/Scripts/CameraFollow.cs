using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;  // Player to follow
    [SerializeField] private Vector3 offset;    // Offset from the player

    public float smoothSpeed = 0.125f;  // Smoothness factor for camera movement

    void LateUpdate()
    {
        // Desired position of the camera
        Vector3 desiredPosition = player.position + offset;

        // Smooth transition between current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update camera position
        transform.position = smoothedPosition;
    }
}
