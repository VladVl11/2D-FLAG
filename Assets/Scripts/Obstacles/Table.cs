using Unity.Mathematics;
using UnityEngine;


public class Table : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            stats.SetSpeed(1f / 6f, true);
        }
    }
}
