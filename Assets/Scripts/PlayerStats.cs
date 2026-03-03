using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float mSpeed;
    private float currentSpeed;
    public bool isStunnable = true;
    private float jForce = 6f;

    private void Awake()
    {
        currentSpeed = mSpeed;
    }

    /////////
    /// GETTERS
    public float GetSpeed()
    {
        return currentSpeed;
    }

    public float GetJForce()
    {
        return jForce;
    }
    /////////

    public void Slow(float modif)
    {
        currentSpeed /= modif;
    }

    public void normalSpeed()
    {
        currentSpeed = mSpeed;
    }

    public IEnumerator Stun()
    {
        float tmp = currentSpeed;
        currentSpeed = 0;
        yield return new WaitForSeconds(1f);
        currentSpeed = tmp;
        isStunnable = false;
        yield return new WaitForSeconds(1f);
        isStunnable = true;
    }
}
