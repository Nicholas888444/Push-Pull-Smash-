using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextUpdater : MonoBehaviour
{
    public TextMeshProUGUI menu;
    public String message;
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
            menu.text = message;
    }
}
