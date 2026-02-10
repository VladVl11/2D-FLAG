using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    private float hp = 50;
    private float mSpeed;

    public float GetSpeed()
    {
        return mSpeed;
    }

    public void TakeDmg(float dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
            Destroy(this);
        }
    }


}
