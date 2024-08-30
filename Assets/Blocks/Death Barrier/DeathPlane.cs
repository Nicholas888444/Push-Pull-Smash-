using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public Pause menu;
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
            menu.Death();
    }
}
