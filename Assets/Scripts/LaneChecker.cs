using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneChecker : MonoBehaviour {

    private PinSetter pinSetter;

    private void Start() {
        pinSetter = FindObjectOfType<PinSetter>();
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Ball") {
            pinSetter.ballExitedLane = true;
        }
    }
}
