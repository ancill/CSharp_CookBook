using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        // Controll player movement
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        transform.Translate(Vector3.right * (Time.deltaTime * turnSpeed * horizontalInput));
    }
}
