using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bSpeed;
    private float bDmg = 10;

    private void Update()
    {
        transform.position += transform.right * bSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDmg(bDmg);
            Debug.Log("hit");
        }
        Destroy(this);
    }
}
