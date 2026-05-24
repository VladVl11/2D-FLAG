using UnityEngine;

public class GoLeft : MonoBehaviour
{

    private void Awake()
    {
        if(transform.childCount > 0)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.AddComponent<Obstacle_destroy>();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 5 * Time.deltaTime);
        if(transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
