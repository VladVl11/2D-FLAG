using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private float MSpeed;
    private Vector2 Dir;
    private Weapon Gun;

    private void OnMove(InputValue value) {
        Dir = value.Get<Vector2>();
    }

    private void OnAttack()
    {
        Gun.Fire();
    }

    private void Awake() {
        Gun = GetComponentInChildren<Weapon>();
    }

    private void FixedUpdate(){
        transform.Translate(Dir * MSpeed * Time.deltaTime);
    }
}
