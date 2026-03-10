using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Vector3 offset = new Vector3(0, 0, -10f); // Offset from the player character
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player; // Reference to the player character's transform


  
    void Update()
    {
        Vector3 targetPosition = player.position + offset; // Desired camera position based on the player's position and the offset
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime); // Smoothly move the camera towards the target position
    }
}
