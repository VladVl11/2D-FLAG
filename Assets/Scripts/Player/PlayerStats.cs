using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    // Movement variables
    private float mSpeed;
    private float currentSpeed;
    private float jForce = 6f;

    // Stun variables
    public bool isStunnable = true;
    public bool stunned = false;
    private float stunTimer = 0f;
    private float stunTime = 1f;
    private float notStunnableTime = 2f;
    
    // Trip variables
    private bool isTripped = false;
    private float trippTimer = 0f;
    private float trippTime = 0.5f;


    private void Awake()
    {
        currentSpeed = mSpeed;
    }

    private void Update()
    {
        if(stunned || !isStunnable)
        {
            stunTimer += Time.deltaTime;
            if(stunTimer > stunTime && stunned)
            {
                stunned = false;
            }
            else if(stunTimer > notStunnableTime && !isStunnable)
            {
                isStunnable = true;
                stunTimer = 0f;
            }
        }
        if(isTripped)
        {
            trippTimer += Time.deltaTime;
            if(trippTimer > trippTime)
            {
                currentSpeed = mSpeed;
                isTripped = false;
            }
        }
    } 

    /// Getters
    public float GetSpeed()
    {
        return currentSpeed;
    }

    public float GetJForce()
    {
        return jForce;
    }

    /// Setters
    public void SetSpeed(float modif)
    {
        currentSpeed *= modif;
    }

    public void SetSpeed(float modif, bool tripped)
    {
        currentSpeed *= modif;
        isTripped = tripped;
    }

    /// Functions
    public void Stun()
    {
        if(isStunnable)
        {
            isStunnable = false;
            stunned = true;
        }
    }
}
