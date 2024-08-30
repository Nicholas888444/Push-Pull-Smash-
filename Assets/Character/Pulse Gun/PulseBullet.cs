using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBullet : MonoBehaviour
{
    public int wallLayer;
    public GameObject pulseObject, pulseEffects;
    

    void OnCollisionEnter(Collision collision) {
        //print(collision.gameObject.layer);
        Rigidbody selfRb = GetComponent<Rigidbody>();
        selfRb.constraints = RigidbodyConstraints.FreezeAll;

        GameObject pulse = Instantiate(pulseObject, transform);
        pulse.transform.localScale *= (1/transform.localScale.x); 
        Destroy(gameObject, 0.25f);
        /*Physics.OverlapSphere(transform.position, 3.0f);
        raycastHitInfo.
        Destroy(gameObject, 2.0f);*/

        
        /*if(collision.gameObject.layer == wallLayer) {
            Rigidbody selfRb = GetComponent<Rigidbody>();
            selfRb.constraints = RigidbodyConstraints.FreezeAll;

            GameObject pulse = Instantiate(pulseObject, transform);
            pulse.transform.localScale *= (1/transform.localScale.x); 
            Destroy(gameObject, 0.25f);
            Physics.OverlapSphere(transform.position, 3.0f);
            raycastHitInfo.
            Destroy(gameObject, 2.0f);

        }*/
    }
}
