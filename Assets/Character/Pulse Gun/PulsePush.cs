using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsePush : MonoBehaviour
{
    public float pushForce = 1000.0f;
    void OnTriggerEnter(Collider other) {
        //print("Hi");
        if(other.gameObject.GetComponent<Rigidbody>() != null) {
            //print("Be gone!");
            Vector3 direction = (transform.position - other.transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * -pushForce, ForceMode.Impulse);
            if(other.gameObject.tag == "Player") {
                other.gameObject.GetComponent<CharacterMovement>().DelaySpeed();
            }
        }
    }
}
