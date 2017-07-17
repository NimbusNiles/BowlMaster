using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

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
        List<int> frameScores = new List<int>();

        bool previousBowlClosedFrame = true;

        for(int ii = 0; ii < bowls.Count; ii++) {

            if (frameScores.Count == 10) { break; }

            int futureBowls = bowls.Count - (ii + 1);

            if (!previousBowlClosedFrame) {
                if (bowls[ii] + bowls[ii - 1] == 10) { // Spare!
                    if (futureBowls >= 1) {
                        frameScores.Add(bowls[ii - 1] + bowls[ii] + bowls[ii + 1]);
                        previousBowlClosedFrame = true;
                        continue;
                    }
                } else { // Normal frame ending
                    frameScores.Add(bowls[ii - 1] + bowls[ii]);
                    previousBowlClosedFrame = true;
                    continue;
                }
            } else if (bowls[ii] == 10) { // Strike!
                if (futureBowls >= 2) {
                    frameScores.Add(bowls[ii] + bowls[ii + 1] + bowls[ii + 2]);
                    previousBowlClosedFrame = true;
                    continue;
                }
            } else {
                previousBowlClosedFrame = false;
            }
        }

        return frameScores;
    }
    
}
