using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
    
    public float standingThreshold;

    public bool IsStanding() {
        if (transform.up.y > 0.8f) {
            return true;
        } else {
            return false;
        }

    }

}
