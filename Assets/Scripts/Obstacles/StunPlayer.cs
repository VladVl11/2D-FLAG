using UnityEngine;

public class StunPlayer : MonoBehaviour
{
    private PlayerStats stats;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerStats>(out stats))
        {
            stats.Stun();
        }
    }

    
}
