using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private Vector2 dir;
    private Weapon gun;
    private PlayerStats stats;

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
    }

    private void FixedUpdate(){
        transform.Translate(dir * stats.GetSpeed() * Time.deltaTime);
    }
}
