using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStats : MonoBehaviour
{
    
    // Movement variables
    [SerializeField] private float mSpeed;
    private float currentSpeed;
    private float jForce = 3.4f;

    // Stun variables
    private bool isStunnable = true;
    public bool stunned = false;
    private float stunTimer = 0f;
    private float stunTime = 1f;
    private float notStunnableTime = 1f;
    
    // Trip variables
    public bool tripped = false;
    private float trippTime = 0.5f;

    // References
    private Rigidbody2D rb;


    private void Awake()
    {
        currentSpeed = mSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(stunned)
        {
            stunTimer += Time.deltaTime;
            if(stunTimer > stunTime)
            {
                stunned = false;
                stunTimer = 0f;
            }
        }

        if(tripped)
        {
            stunTimer += Time.deltaTime;
            if(stunTimer > trippTime)
            {
                tripped = false;
                stunTimer = 0f;
            }
        }
        if(!isStunnable && !stunned && !tripped)
        {
            stunTimer += Time.deltaTime;
            if(stunTimer > notStunnableTime)
            {
                isStunnable = true;
                stunTimer = 0f;
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

    /// Functions
    public void Stun()
    {
        if(isStunnable)
        {
            isStunnable = false;
            stunned = true;
        }
    }

    public void Tripp(Transform obj)
    {
        if(isStunnable)
        {
            isStunnable = false;
            tripped = true;
            rb.AddForce((obj.position - transform.position) * 0.01f, ForceMode2D.Impulse);
        }
    }
}
