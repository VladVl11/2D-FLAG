using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SceneLoad();
        }
    }
}
