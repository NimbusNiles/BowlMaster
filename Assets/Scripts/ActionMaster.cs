using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

    public enum BowlAction {Tidy, Reset, EndTurn, EndGame };

    private int[] bowls = new int[21];
    private int bowl = 1;

    public static BowlAction NextAction(List<int> bowls) {
        ActionMaster actionMaster = new ActionMaster();
        BowlAction NextBowlAction = new BowlAction();

        foreach(int bowl in bowls) {
            NextBowlAction = actionMaster.Bowl(bowl);
        }

        return NextBowlAction;
    }

	private BowlAction Bowl (int pins) {
        if (pins < 0 || pins > 10) {throw new UnityException("Impossible number of pins recorded: " + pins); }

        bowls[bowl - 1] = pins;

        if (bowl == 21) {
            return BowlAction.EndGame;
        }

        if ((bowl == 19 || bowl == 20) && pins == 10){
            bowl += 1;
            return BowlAction.Reset;
        }

        if (bowl == 20 && bowls[bowl-2] == 10) {
            bowl += 1;
            return BowlAction.Tidy;
        }

        if (bowl == 20) {
            int lastAndThisBowlTotal = bowls[bowl - 2] + bowls[bowl - 1];
            if (lastAndThisBowlTotal == 10) {
                bowl += 1;
                return BowlAction.Reset;
            } else {
                return BowlAction.EndGame;
            }
        }

        if (pins == 10 && bowl % 2 != 0) {
            bowl += 2;
            return BowlAction.EndTurn;
        }

        if (bowl % 2 != 0) {
            bowl += 1;
            return BowlAction.Tidy;
        } else if (bowl % 2 == 0) {
            bowl += 1;
            return BowlAction.EndTurn;
        }

        throw new UnityException("Not sure what action to return.");
    }
}
