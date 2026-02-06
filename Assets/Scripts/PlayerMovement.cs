using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float MSpeed;
    private Vector2 Dir;
    private Rigidbody2D RB;

    private void OnMove() {
        
    }

    private void Awake() {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        RB.AddForce(Dir * MSpeed * Time.deltaTime);
    }
}
