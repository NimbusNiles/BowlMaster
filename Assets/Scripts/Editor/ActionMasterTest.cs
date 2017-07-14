using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ActionMasterTest {
    
    private ActionMaster.BowlAction endTurn = ActionMaster.BowlAction.EndTurn;
    private ActionMaster.BowlAction tidy = ActionMaster.BowlAction.Tidy;
    private ActionMaster.BowlAction reset = ActionMaster.BowlAction.Reset;
    private ActionMaster.BowlAction endGame = ActionMaster.BowlAction.EndGame;
    

    [SetUp]
    public void Setup() {
    }

    //[Test]
    //public void T00PassingTest() {
    //    Assert.AreEqual(1, 1);
    //}

    //[Test]
    //public void T01FailingTest() {
    //    Assert.AreEqual(1, 2);
    //}

    [Test]
    public void T02OneStrikeReturnsEndTurn() {
        int[] rolls = { 10 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T03Bowl8ReturnsTidy() {
        int[] rolls = { 8 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04Bowl28ReturnsEndTurn() {
        int[] rolls = { 2, 8 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T05StrikeInLastFrameReturnsReset() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10};
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T06ZeroThrowAfterTurn19StrikeReturnsTidy() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0};
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07TypicalGameNoStrikeEndGameAtTurn20() {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 2, 2 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08TypicalGameStrikeEndGameAtTurn21() {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 10, 2, 3 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T09TypicalGameSpareEndGameAtTurn21() {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 3, 7 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T10TypicalGameTurn20TidyAfterStrike() {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 10, 3 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T11TypicalGameTurn20ResetAfterStrike() {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 10, 10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T12Bowl10OnSecondThrowOfTurnIncrementsBowlWithOne() {
        int[] rolls = { 0, 10, 5 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T13TypicalGameEndGameAfter3StrikesInLastFrame() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }


}
