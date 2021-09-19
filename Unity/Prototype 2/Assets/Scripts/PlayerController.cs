using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;

    public float speed = 10.0f;
    public float xRange = 10;

    public GameObject projectilePrefab;
    // Update is called once per frame
    void Update()
    {
        var transformLocal = transform;
        if (transform.position.x < -xRange)
            transformLocal.position = new Vector3(-xRange, transform.position.y, transformLocal.position.z);
        if (transform.position.x > xRange) 
            transformLocal.position = new Vector3(xRange, transform.position.y, transformLocal.position.z);
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (Time.deltaTime * horizontalInput * speed));
        
        // lunch a projectile from a player
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
