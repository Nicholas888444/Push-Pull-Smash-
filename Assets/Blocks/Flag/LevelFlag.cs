using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlag : MonoBehaviour
{
    public Pause menu;
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
            menu.FinishLevel();
    }
}
