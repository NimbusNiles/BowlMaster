using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PinCounter : MonoBehaviour {

    public bool ballExitedLane = false;
    public int lastSettledCount;

    public static event Action<int> OnPinsFallen;

    private float lastChangeTime;
    private float timeSinceBallEntered;
    private Pin[] pins;
    private Text text;
    private int lastStandingCount = -1;

    private void OnEnable() {
        LaneChecker.OnBallExitsLane += (() => ballExitedLane = true);
    }

    private void Start() {
        text = GameObject.Find("Pin Count").GetComponent<Text>();
        ResetPinCount();
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

    public void ResetPinCount() {
        lastSettledCount = 10;
        pins = FindObjectsOfType<Pin>();
    }

    int CountStanding() {
        int pinCount = 0;

        foreach (Pin pin in pins) {
            if (pin) {
                if (pin.IsStanding()) {
                    pinCount++;
                }
            }
        }

        return pinCount;
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

        // Broadcast pins fallen event
        OnPinsFallen(pinsFallen);
        
    }
}
