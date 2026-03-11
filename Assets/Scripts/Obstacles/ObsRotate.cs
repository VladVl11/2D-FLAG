using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ObsRotate : MonoBehaviour
{
    private bool used = false;
    private Quaternion rot;
    private float rotSpeed = 0.5f;

    private void Awake()
    {
        rot = transform.rotation * Quaternion.Euler(0, 0, -90);
    }

    private void Update()
    {
        if(used && transform.rotation.z != -90f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotSpeed);
            Debug.Log("rotating");
            rotSpeed += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !used)
        {
            used = true;
            Debug.Log("touched");
        }
    }
}
