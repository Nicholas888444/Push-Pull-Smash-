using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockUpdater : MonoBehaviour
{
    public Transform newPoint;
    public float speed;

    public Vector3 rot;
    void OnTriggerEnter(Collider other) {
        other.TryGetComponent<MovingBlock>(out MovingBlock component);
        if(component != null) {
            print("Done");
            component.movePoint = newPoint;
            component.speed = speed;

            component.transform.eulerAngles = rot;
        }
    }
}
