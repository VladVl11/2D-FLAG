using System.Runtime.CompilerServices;
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
    [SerializeField] private LayerMask gLayer;

    private void OnMove(InputValue value) {
        if(!stats.stunned)
        {
            dir = value.Get<Vector2>();
        }
    }
    private void OnAttack()
    {
        if(!stats.stunned)
        {
            gun.Fire();
        }
    }
    private void OnJump()
    {
        if(timesJumped < 1 && !stats.stunned)
        {
            Debug.Log("jumping");
            rb.AddForce(Vector2.up * stats.GetJForce(), ForceMode2D.Impulse);
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
        rb.linearVelocity = new Vector2(Mathf.Lerp(rb.linearVelocityX, dir.x * stats.GetSpeed(), 0.25f), rb.linearVelocityY);
        if(Physics2D.OverlapCircle(gCheck.position, 0.1f, gLayer) && timesJumped >0)
        {
            timesJumped = 0;
        }
    }
}
