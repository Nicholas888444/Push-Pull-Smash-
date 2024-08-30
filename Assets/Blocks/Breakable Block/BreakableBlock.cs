using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    public float breakForce;
    public GameObject effect;
    void OnCollisionEnter(Collision collision) {
        //print(collision.gameObject.layer);
        if(collision.gameObject.tag == "Player") {
            Vector3 impulse = collision.impulse;
            float magnitude = impulse.magnitude;
            print(magnitude);
            if(magnitude > breakForce) {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
