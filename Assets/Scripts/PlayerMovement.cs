using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private float MSpeed;
    private Vector2 Dir;
    private Rigidbody2D RB;
    private Weapon Gun;

    private void OnMove(InputValue value) {
        Dir = value.Get<Vector2>();
    }

    private void OnAttack()
    {
        Gun.Fire();
    }

    private void Awake() {
        RB = GetComponent<Rigidbody2D>();
        Gun = GetComponentInChildren<Weapon>();
    }

    private void FixedUpdate() {
        RB.linearVelocity = Dir * MSpeed;   
    }
}
