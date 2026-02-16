using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private Vector2 dir;
    private Weapon gun;
    private PlayerStats stats;
    private Rigidbody2D rb;
    [SerializeField] Transform gCheck;

    private void OnMove(InputValue value) {
        dir = value.Get<Vector2>();
    }
    private void OnAttack()
    {
        gun.Fire();
    }
    private void OnJump()
    {
        
    }

    private void Awake() {
        gun = GetComponentInChildren<Weapon>();
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        rb.linearVelocity = new Vector2(dir.x * stats.GetSpeed(), rb.linearVelocityY);
    }
}
