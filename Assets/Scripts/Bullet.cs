using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float BSpeed;
    private void Update()
    {
        transform.position += transform.right * BSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(!other.gameObject.CompareTag("Player")) {
            Destroy(this);
        }
    }
}
