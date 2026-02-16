using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private Vector2 dir;
    private Weapon gun;
    private PlayerStats stats;
    private Rigidbody2D rb;

    private void OnMove(InputValue value) {
        dir = value.Get<Vector2>();
    }
    private void OnAttack()
    {
        gun.Fire();
    }

    private void Awake() {
        gun = GetComponentInChildren<Weapon>();
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        rb.linearVelocity += dir * stats.GetSpeed() * Time.deltaTime;
    }
}
