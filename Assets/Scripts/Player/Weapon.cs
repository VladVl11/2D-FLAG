using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    // Weapon rotation variables
    private Vector3 MPos;
    private Vector3 MDir;
    private float angle;

    // Fire-rate variables
    private bool canFire = true;
    private float fireTimer = 0f;
    private float fireTime = 0.15f;

    private void Update() {
        MPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        MDir = MPos - transform.position;

        angle = Mathf.Atan2(MDir.y, MDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if(!canFire)
        {
            fireTimer += Time.deltaTime;
            if(fireTimer > fireTime)
            {
                canFire = true;
                fireTimer = 0f;
            }
        }
    }

    public void Fire() {
        if(canFire)
        {
            Instantiate(bullet, transform.position + transform.right * 0.5f, transform.rotation);
            canFire = false;
        }
    }
}
