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
        if(other.gameObject.CompareTag("Player") && !triggered)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            triggered = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().StartCoroutine("Stun");
        }
        Debug.Log("FUCKIGN DESTROY DAMMIT");
        Destroy(this.gameObject);
    }
}
