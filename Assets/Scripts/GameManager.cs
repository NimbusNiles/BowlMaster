using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> bowls = new List<int>();
    private PinSetter pinSetter;
    private Ball ball;

    private void OnEnable() {
        PinCounter.OnPinsFallen += ResolveBowl;
    }

    private void OnDisable() {
        PinCounter.OnPinsFallen -= ResolveBowl;
    }

    private void Start() {
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
    }

    void ResolveBowl(int pinsFallen) {
        ball.Reset();

        bowls.Add(pinsFallen);
        pinSetter.SetPins(ActionMaster.NextAction(bowls));

        //Ask scoremaster for the score list
    }

}
