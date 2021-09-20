using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBound = 30;
    private float lowBound = -10;
    void Update()
    {
        if(transform.position.z > topBound) Destroy(gameObject);
        else if(transform.position.z < lowBound) Destroy(gameObject);
    }
}
