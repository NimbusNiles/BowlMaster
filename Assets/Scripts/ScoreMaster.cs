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

        bool previousBowlClosedFrame = true;
        bool thisBowlClosedFrame = false;

        for(int ii = 0; ii < bowls.Count; ii++) { 

            if(!previousBowlClosedFrame) {
                thisBowlClosedFrame = true;
            }

            if (thisBowlClosedFrame) {
                frameList.Add(bowls[ii - 1] + bowls[ii]);
            }

            previousBowlClosedFrame = thisBowlClosedFrame;
            thisBowlClosedFrame = false;
        }

        return frameList;
    }
    
}
