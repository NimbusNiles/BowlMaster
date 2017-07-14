using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

    public static List<int> CumulativeScore(List<int> bowls) {
        List<int> cumulativeScores = new List<int>();
        List<int> frameScores = FrameScores(bowls);
        int runningTotal = 0;

        foreach (int frameScore in frameScores) {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;

    }

    public static List<int> FrameScores(List<int> bowls) {
        List<int> frameList = new List<int>();


        return frameList;
    }
    
}
