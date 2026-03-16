using UnityEngine;

public class Cauldron : MonoBehaviour, IDamageable
{
    private float hp = 1;


    public void TakeDmg(float dmg)
    {
        hp -= dmg;
        if(hp >= 0)
        {
            Explode();
            Destroy(this.gameObject);
        }
    }

    private void Explode()
    {
        foreach(Collider2D obj in Physics2D.OverlapCircleAll(transform.position, 10f))
        {
            if(obj.gameObject.CompareTag("Player"))
            {
                obj.GetComponent<Rigidbody2D>().AddForce((obj.transform.position - this.transform.position).normalized * 30f, ForceMode2D.Impulse);
            }
        }
    }
}
