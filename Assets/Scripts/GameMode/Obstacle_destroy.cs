using UnityEngine;

public class Obstacle_destroy : MonoBehaviour
{
    private void Update()
    {
            Vector3 viewportPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
            if (viewportPos.x < -1)
            {
                Destroy(this.gameObject);
            }
    }
}
