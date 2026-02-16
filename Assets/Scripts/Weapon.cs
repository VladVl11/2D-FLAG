using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private Vector3 MPos;
    private Vector3 MDir;
    private float angle;

    private void Update() {
        MPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        MDir = MPos - transform.position;

        angle = Mathf.Atan2(MDir.y, MDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void Fire() {
        Instantiate(bullet, transform.position + transform.right * 0.5f, transform.rotation);
    }
}
