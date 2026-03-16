using UnityEngine;

public class Chandelier : MonoBehaviour
{
    private bool triggered = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            triggered = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            stats.Stun();
        }
        Destroy(this.gameObject);
    }
}
