using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleBullet : MonoBehaviour
{
    private GrappleGun grappleGun;
    public int wallLayer;
    private Transform attachedTransform;
    private Vector3 previousPosition;

    void Update() {
        transform.LookAt(transform.position + GetComponent<Rigidbody>().velocity.normalized);// = transform.position + GetComponent<Rigidbody>().velocity.normalized;

        if(attachedTransform != null) {
            if(attachedTransform.position != previousPosition) {
                Vector3 positionDifference = previousPosition - attachedTransform.position;
                
                transform.position -= positionDifference;
            }
            
            previousPosition = attachedTransform.position;
        }
    }
    

    void OnCollisionEnter(Collision collision) {
        print(collision.gameObject.layer);
        if(collision.gameObject.layer == wallLayer) {
            Rigidbody selfRb = GetComponent<Rigidbody>();
            selfRb.constraints = RigidbodyConstraints.FreezeAll;

            if(grappleGun != null) {
                grappleGun.CollisionFound();
            }

            attachedTransform = collision.gameObject.transform;
            previousPosition = attachedTransform.position;
        } else {
            grappleGun.DeleteBullet();
        }
    }

    public void SetGun(GrappleGun gg) {
        grappleGun = gg;
    }
}
