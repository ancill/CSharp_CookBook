using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBound = 30;
    void Update()
    {
        if(transform.position.z > topBound) Destroy(gameObject);
    }
}
