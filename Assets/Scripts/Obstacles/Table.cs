using Unity.Mathematics;
using UnityEngine;


public class Table : MonoBehaviour, IDamageable
{
    private float hp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            stats.Tripp(transform);
        }
    }

    public void TakeDmg(float dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
