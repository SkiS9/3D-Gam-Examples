using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ObjectToFollow;
    Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
     _offset = transform.position - ObjectToFollow.transform.position;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
       transform.position = ObjectToFollow.transform.position + _offset;
    }
}
