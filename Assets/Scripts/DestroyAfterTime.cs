using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float DestroyAfter;

    void Awake() {
        Destroy(gameObject, DestroyAfter);
    }
}
