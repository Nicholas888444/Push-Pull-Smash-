using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseGun : MonoBehaviour
{
    public Rigidbody player;
    private CharacterMovement cm;
    public float pushForce;
    public Transform handPosition;
    public Transform cameraOrientation;
    public GameObject bullet;
    public float bulletSpeed;
    private Transform pulseEnd;
    public Camera playerCam;
    public bool working;
    public int charges = 1;
    private int currentCharges;

    void Awake() {
        pulseEnd = transform.GetChild(1);
        currentCharges = charges;

        cm = player.gameObject.GetComponent<CharacterMovement>();
    }

    


    // Update is called once per frame
    void Update()
    {
        transform.position = handPosition.position;
        transform.forward = cameraOrientation.forward;

        if(cm.grounded) {
            ResetCharges();
        }


        if (Input.GetButtonDown("Fire1") && working)
        {
            if(currentCharges <= 0) {
                return;
            }
            currentCharges -= 1;
            Vector3 direction = playerCam.transform.forward;
            player.AddForce(direction * -pushForce, ForceMode.Impulse);


        }
    }

    public void ResetCharges() {
        currentCharges = charges;
    }
}
