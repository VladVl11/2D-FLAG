using UnityEngine;

public class Chandelier : MonoBehaviour
{
    private bool triggered = false;
    private float speed = 5;

    private void Update()
    {
        if(triggered)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
            Debug.Log("Falling");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !triggered)
        {
            triggered = true;
            Debug.Log("Triggered");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().StartCoroutine("Stun");
        }
    }
}
