using Unity.VisualScripting;
using UnityEngine;

public class spikes : MonoBehaviour
{
    PlayerStats stats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && stats == null)
        {
            stats = other.GetComponent<PlayerStats>();
        }
        if(stats != null)
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
        stats = null;
    }
}
