using UnityEngine;

public class spikes : MonoBehaviour
{
    private float dmg = 10;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDmg(10);
        }
    }
}
