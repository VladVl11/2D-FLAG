using UnityEngine;

public class SpinningSpikeball : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject ball;
    public GameObject chain;
    public GameObject body;
    public float chainLength;
    private float ballLength;
    private float chainWidth = 0.075f;
    void Start()
    {
        ballLength = chainLength * 1.25f;
        GameObject newChain = Instantiate(chain, new Vector3(chainLength, 0, 0), Quaternion.identity);
        newChain.transform.SetParent(body.transform);
        newChain.transform.localScale = new Vector3(chainLength, chainWidth, 1);
        newChain.transform.localPosition = new Vector3(chainLength / 2, 0, 0);
        GameObject newBall = Instantiate(ball, new Vector3(chainLength, 0, 0), Quaternion.identity);
        newBall.transform.SetParent(newChain.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }
}


