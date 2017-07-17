using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionMaster {

    public enum BowlAction {Tidy, Reset, EndTurn, EndGame };

    public static BowlAction NextAction(List<int> bowls) {
        
        BowlAction NextBowlAction = new BowlAction();
        
        int bowl = 1;

        for (int ii = 0; ii < bowls.Count; ii++) {

            int pins = bowls[ii];

            if (pins < 0 || pins > 10) { throw new UnityException("Impossible number of pins recorded: " + pins); }

            if (bowl == 21) {
                NextBowlAction = BowlAction.EndGame;
                continue;
            }

            if ((bowl == 19 || bowl == 20) && pins == 10) {
                bowl += 1;
                NextBowlAction = BowlAction.Reset;
                continue;
            }

            if (bowl == 20 && bowls[ii - 1] == 10) {
                bowl += 1;
                NextBowlAction = BowlAction.Tidy;
                continue;
            }

            if (bowl == 20) {
                int lastAndThisBowlTotal = bowls[ii - 1] + bowls[ii];
                if (lastAndThisBowlTotal == 10) {
                    bowl += 1;
                    NextBowlAction = BowlAction.Reset;
                    continue;
                } else {
                    NextBowlAction = BowlAction.EndGame;
                    continue;
                }
            }
            
            if (pins == 10 && bowl % 2 != 0) {
                bowl += 2;
                NextBowlAction = BowlAction.EndTurn;
                continue;
            }

            if (bowl % 2 != 0) {
                bowl += 1;
                NextBowlAction = BowlAction.Tidy;
                continue;
            } else if (bowl % 2 == 0) {
                bowl += 1;
                NextBowlAction = BowlAction.EndTurn;
                continue;
            }

            throw new UnityException("Not sure what action to return.");

        }

        return NextBowlAction;
    }
}
