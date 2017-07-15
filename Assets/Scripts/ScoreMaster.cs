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

            bool strike = false;
            bool spare = false;

            int futureBowls = bowls.Count - (ii + 1);

            if (bowls[ii] == 10 && previousBowlClosedFrame) {
                strike = true;
                thisBowlClosedFrame = true;
            }

            if (!previousBowlClosedFrame) {
                thisBowlClosedFrame = true;
                if (bowls[ii] + bowls[ii - 1] == 10) {
                    spare = true;
                }
            }
            
            if (thisBowlClosedFrame) {
                if (strike) {
                    if (futureBowls >= 2) {
                        frameList.Add(bowls[ii] + bowls[ii + 1] + bowls[ii + 2]);
                    }
                } else if (spare) {
                    if (futureBowls >= 1) {
                        frameList.Add(bowls[ii -1] + bowls[ii] + bowls[ii + 1]);
                    }
                } else {
                    frameList.Add(bowls[ii - 1] + bowls[ii]);
                }

            }

            previousBowlClosedFrame = thisBowlClosedFrame;
            thisBowlClosedFrame = false;

            if (frameList.Count == 10) {
                break;
            }
        }

        return frameList;
    }
    
}
