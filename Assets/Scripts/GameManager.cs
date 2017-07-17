using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> bowls = new List<int>();
    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

    private void OnEnable() {
        PinCounter.OnPinsFallen += ResolveBowl;
    }

    private void OnDisable() {
        PinCounter.OnPinsFallen -= ResolveBowl;
    }

    private void Start() {
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    void ResolveBowl(int pinsFallen) {
        bowls.Add(pinsFallen);
        pinSetter.SetPins(ActionMaster.NextAction(bowls));

        List<int> frameScores = ScoreMaster.FrameScores(bowls);
        scoreDisplay.FillBowlCard(bowls);

        ball.Reset();
    }

}
