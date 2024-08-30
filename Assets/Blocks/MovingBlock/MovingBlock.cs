using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Transform movePoint;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movePoint != null) {
            Vector3 direction = (movePoint.position - transform.position).normalized;
            transform.position += direction*speed*Time.deltaTime;
            //transform.Translate(direction*speed*Time.deltaTime);
        }
    }
}
