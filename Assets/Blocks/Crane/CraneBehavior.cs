using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneBehavior : MonoBehaviour
{
    private LineRenderer lr;
    public Transform baseObj, attatchedObj;
    public bool rotate;
    public bool rightDirection;
    private Transform pivot;
    public float rotationSpeed;

    void Awake() {
        lr = GetComponent<LineRenderer>();
        pivot = transform.GetChild(1);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(lr != null) {
            lr.SetPosition(0, baseObj.position);
            lr.SetPosition(1, attatchedObj.position);
        }

        if(rotate) {
            Vector3 direction = Vector3.up;
            if(rightDirection) {
                pivot.Rotate(rotationSpeed * direction * Time.deltaTime);
            } else {
                direction *= -1;
                pivot.Rotate(rotationSpeed * direction * Time.deltaTime);
            }
        }
    }
}
