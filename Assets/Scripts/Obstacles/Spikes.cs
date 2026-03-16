using Unity.VisualScripting;
using UnityEngine;

public class spikes : MonoBehaviour
{
    private PlayerStats stats;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<PlayerStats>(out stats))
        {
            stats.SetSpeed(1f / 3f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(stats != null)
        {
            stats.SetSpeed(3f);
        }
    }
}
