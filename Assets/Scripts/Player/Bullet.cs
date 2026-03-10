using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bSpeed;
    private float bDmg = 1;

    private void Update()
    {
        transform.position += transform.right * bSpeed * Time.deltaTime;
        Destroy(this.gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.TryGetComponent<IDamageable>(out IDamageable obs))
        {
            obs.TakeDmg(bDmg);
        }
        Destroy(this.gameObject);
    }
}
