using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 _offset = new Vector3(20, 0, 7);

    void LateUpdate()
    {
        transform.position = plane.transform.position + _offset;
    }
}
