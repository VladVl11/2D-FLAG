using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerActions : MonoBehaviour
{
    private Vector2 dir;
    private Weapon gun;
    private PlayerStats stats;
    private Rigidbody2D rb;
    [SerializeField] Transform gCheck;
    private float timesJumped;
    [SerializeField] private LayerMask gLayer;
    private bool over = false;

    /// Input system functions
    private void OnMove(InputValue value) {
        dir = value.Get<Vector2>();
    }
    private void OnAttack()
    {
        if(!stats.stunned && !stats.tripped)
        {
            gun.Fire();
        }
    }
    private void OnJump()
    {
        if(timesJumped < 1 && !stats.stunned && !stats.tripped)
        {
            rb.linearVelocityY = stats.GetJForce();
            timesJumped++;
        }
    }

    private void Awake() {
        gun = GetComponentInChildren<Weapon>();
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        if (viewportPos.y < 0 && !over)
        {
            GameManager.Instance.GameOver();
            over = true;
        }
    }

    private void FixedUpdate(){
        if(!stats.stunned && !stats.tripped)
        {
            rb.linearVelocity = new Vector2(Mathf.Lerp(rb.linearVelocityX, dir.x * stats.GetSpeed(), 0.25f), rb.linearVelocityY);
        }
        if(!Physics2D.OverlapCircle(gCheck.position, 0.05f, gLayer) && rb.linearVelocityY !< 0)
        {
            rb.linearVelocityY = Mathf.Lerp(rb.linearVelocityY, Physics2D.gravity.y * rb.gravityScale, 0.25f);
        }
        if(Physics2D.OverlapCircle(gCheck.position, 0.05f, gLayer) && timesJumped >0)
        {
            timesJumped = 0;
        }
    }
}
