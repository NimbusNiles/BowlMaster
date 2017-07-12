using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaneChecker : MonoBehaviour {

    public static event Action OnBallExitsLane;

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Ball") {
            OnBallExitsLane();
        }
    }
}
