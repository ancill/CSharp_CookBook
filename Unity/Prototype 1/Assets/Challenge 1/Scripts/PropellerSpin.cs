using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    private float rotationSpeed = 950.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * (Time.deltaTime * rotationSpeed));
        
    }
}
