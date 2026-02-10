using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bSpeed;
    private float bDmg;

    private void Update()
    {
        transform.position += transform.right * bSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(!other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDmg(bDmg);
            }
        }
        
    }
}
