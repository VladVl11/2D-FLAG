using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float mSpeed;
    private float currentSpeed;

    private void Awake()
    {
        currentSpeed = mSpeed;
    }

    public float GetSpeed()
    {
        return currentSpeed;
    }

    private void Slow()
    {
        currentSpeed /= 1.5f;
    }

    private void normalSpeed()
    {
        currentSpeed = mSpeed;
    }

    public IEnumerator Stun()
    {
        float tmp = currentSpeed;
        currentSpeed = 0;
        yield return new WaitForSeconds(1.5f);
        currentSpeed = tmp;
    }
}
