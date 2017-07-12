using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public GameObject pinSet;
    public bool ballExitedLane = false;

    private float lastChangeTime;
    private float timeSinceBallEntered;
    private Ball ball;
    private Pin[] pins;
    private Text text;
    private int lastSettledCount = 10;
    private ActionMaster actionMaster = new ActionMaster();

    private void Start() {
        ball = FindObjectOfType<Ball>();
        pins = FindObjectsOfType<Pin>();
        text = GameObject.Find("Pin Count").GetComponent<Text>();
    }

    private void Update() {
        if (ballExitedLane) {
            text.text = CountStanding().ToString();
            text.color = Color.red;

            CheckStandingCount();

            if (Time.time - lastChangeTime > 3f) {
                PinsHaveSettled();
            }
        }
    }

    void CheckStandingCount() {
        int newStandingCount = CountStanding();

        if (newStandingCount != lastStandingCount) {
            lastStandingCount = newStandingCount;
            lastChangeTime = Time.time;
        }
    }

    void PinsHaveSettled() {
        int pinsFallen = lastSettledCount - CountStanding();
        lastSettledCount = CountStanding();

        lastStandingCount = -1; // indicate pins have settled
        ballExitedLane = false;
        text.color = Color.cyan;
        ball.Reset();

        ActionMaster.BowlAction whatToDo = actionMaster.Bowl(pinsFallen);

        switch (whatToDo) {
            case (ActionMaster.BowlAction.Tidy):
                TidyPins();
                break;
            case (ActionMaster.BowlAction.EndTurn):
            case (ActionMaster.BowlAction.Reset):
                RenewPins();
                break;
            case (ActionMaster.BowlAction.EndGame):
                throw new UnityException("dont know how to end game yet");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<Ball>()) {
            // destroy the ball??
        } else {
            Destroy(other.transform.parent.gameObject);
        }
    }

    int CountStanding() {
        int pinCount = 0;

        foreach(Pin pin in pins) {
            if (pin) { 
                if (pin.IsStanding()) {
                    pinCount++;
                }
            }
        }

        return pinCount;
    }

    private void TidyPins() {
        // Remove all non-standing pins
        foreach (Pin pin in pins) {
            if (pin) {
                if (!pin.IsStanding()) {
                    Destroy(pin.gameObject);
                }
            }
        }
        // Rearrange the left-standing pins (optional)

    }

    private void RenewPins() {
        // Remove all pins
        foreach (Pin pin in pins) {
            if (pin) {
                Destroy(pin.gameObject);
            }
        }

        // Place new pins
        Instantiate(pinSet, new Vector3(0f, 0f, 1829f),Quaternion.identity);

        // Find new pins
        pins = FindObjectsOfType<Pin>();

        lastSettledCount = 10;
    }

}
