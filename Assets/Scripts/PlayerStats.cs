using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float mSpeed;
    private float currentSpeed;
    public bool isStunnable = true;
    private float jForce = 6f;
    public bool stunned = false;

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

    public void SetSpeed(float modif)
    {
        currentSpeed *= modif;
    }

    public IEnumerator Stun()
    {
        if(isStunnable)
        {
            isStunnable = false;
            stunned = true;
            yield return new WaitForSeconds(1f);
            stunned = false;
            yield return new WaitForSeconds(1f);
            isStunnable = true;
        }
    }
}
