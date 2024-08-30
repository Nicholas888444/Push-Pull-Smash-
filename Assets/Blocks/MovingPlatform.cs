using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            other.transform.parent = platform;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            other.transform.parent = null;
        }
    }
}
