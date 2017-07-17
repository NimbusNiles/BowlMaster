using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text[] bowlTexts;
    public Text[] frameTexts;

    private void Start() {
        ClearScores();

    }

    public void FillBowlCard(List<int> bowls) {
        bowls[-1] = 5;
    }

    private void ClearScores() {
        foreach (Text text in bowlTexts) {
            text.text = "";
        }
        foreach (Text text in frameTexts) {
            text.text = "";
        }
    }
}
