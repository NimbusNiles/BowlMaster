using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActionMasterTest {

    private ActionMaster.BowlAction endTurn = ActionMaster.BowlAction.EndTurn;
    private ActionMaster.BowlAction tidy = ActionMaster.BowlAction.Tidy;
    private ActionMaster.BowlAction reset = ActionMaster.BowlAction.Reset;
    private ActionMaster.BowlAction endGame = ActionMaster.BowlAction.EndGame;

    private ActionMaster actionMaster;

    [SetUp]
    public void Setup() {
        actionMaster = new ActionMaster();
    }

    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01FailingTest() {
        Assert.AreEqual(1, 2);
    }

    [Test]
    public void T02OneStrikeReturnsEndTurn() {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T03Bowl8ReturnsTidy() {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T04Bowl28ReturnsEndTurn() {
        actionMaster.Bowl(8);
        Assert.AreEqual(endTurn, actionMaster.Bowl(2));
    }

    [Test]
    public void T05StrikeInLastFrameReturnsReset() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T06ZeroThrowAfterTurn19StrikeReturnsTidy() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
        Assert.AreEqual(tidy, actionMaster.Bowl(0));
    }

    [Test]
    public void T07TypicalGameNoStrikeEndGameAtTurn20() {
        int[] rolls = { 8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 2};
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(2));
    }

    [Test]
    public void T08TypicalGameStrikeEndGameAtTurn21() {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 10,2};
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(3));
    }

    [Test]
    public void T09TypicalGameSpareEndGameAtTurn21() {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2 };
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(3));
    }

    [Test]
    public void T10TypicalGameTurn20TidyAfterStrike() {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 10 };
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(tidy, actionMaster.Bowl(3));
    }

    [Test]
    public void T11TypicalGameTurn20ResetAfterStrike() {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 10 };
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T12Bowl10OnSecondThrowOfTurnIncrementsBowlWithOne() {
        actionMaster.Bowl(0);
        actionMaster.Bowl(10);
        Assert.AreEqual(tidy, actionMaster.Bowl(5));
    }

    [Test]
    public void T13TypicalGameEndGameAfter3StrikesInLastFrame() {
        int[] rolls = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 };
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
        Assert.AreEqual(reset, actionMaster.Bowl(10));
        Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }


}
