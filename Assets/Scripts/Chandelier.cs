using UnityEngine;
using UnityEngine.Windows.Speech;

public class Chandelier : MonoBehaviour
{
    private bool triggered = false;
    private float speed = 20;
    private float dmg = 30;

    private void Update()
    {
        if(triggered)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            triggered = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDmg(dmg);
        }
        Destroy(this);
    }
}
