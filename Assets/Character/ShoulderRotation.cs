using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoulderRotation : MonoBehaviour
{
    public Transform head;

    // Update is called once per frame
    void Update()
    {
        //rotate cam and orientation
        transform.rotation = head.rotation;
    }
}
