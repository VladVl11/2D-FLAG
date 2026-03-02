using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private Vector2 dir;
    private Weapon gun;
    private PlayerStats stats;
    private Rigidbody2D rb;
    [SerializeField] Transform gCheck;
    private float timesJumped;
    [SerializeField] private float jForce;
    [SerializeField] private LayerMask gLayer;

    private void OnMove(InputValue value) {
        dir = value.Get<Vector2>();
    }
    private void OnAttack()
    {
        gun.Fire();
    }
    private void OnJump()
    {
        if(Physics2D.OverlapCircle(gCheck.position, 0.1f, gLayer) || timesJumped < 1)
        {
            Debug.Log("jumping");
            rb.AddForce(Vector2.up * jForce, ForceMode2D.Impulse);
            timesJumped++;
            Debug.Log(timesJumped);
        }
    }

    private void Awake() {
        gun = GetComponentInChildren<Weapon>();
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        rb.linearVelocity = new Vector2(Mathf.Lerp(rb.linearVelocityX, dir.x * stats.GetSpeed(), 0.2f), rb.linearVelocityY);
        if(Physics2D.OverlapCircle(gCheck.position, 0.1f, gLayer) && timesJumped >0)
        {
            timesJumped = 0;
        }
    }
}
