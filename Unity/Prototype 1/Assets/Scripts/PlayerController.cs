using System;
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
        forwardInput = Input.GetAxis("Vertical");
        
        // Controll player movement
        transform.Translate(Vector3.forward * (Time.deltaTime * speed * forwardInput));
        transform.Translate(Vector3.right * (Time.deltaTime * turnSpeed * horizontalInput));
    }
}
