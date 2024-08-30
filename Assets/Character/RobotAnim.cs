using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class RobotAnim : MonoBehaviour
{
    public Transform robotBase;
    public Transform rotation;
    public Animator animator;
    private CharacterMovement characterMovement;
    private Rigidbody characterRb;

    void Awake() {
        characterMovement = GetComponent<CharacterMovement>();
        characterRb = GetComponent<Rigidbody>();
    } 

    // Update is called once per frame
    void Update()
    {
        robotBase.transform.rotation = rotation.transform.rotation;
        float speedMagnitude = characterRb.velocity.magnitude;
        bool grounded = characterMovement.grounded;

        bool set = grounded && (speedMagnitude != 0);
        animator.SetBool("Walking", set);

        animator.SetFloat("WalkSpeed", speedMagnitude);
        animator.SetBool("Air", !grounded);
        
    }
}
