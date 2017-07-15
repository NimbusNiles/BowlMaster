using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScoreMasterTest {

    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl23() {
        int[] bowls = { 2, 3 };
        int[] expectedScores = { 5 };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

    [Test]
    public void T02Bowl2323() {
        int[] bowls = { 2, 3, 2, 3 };
        int[] expectedScores = { 5, 5 };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

    [Test]
    public void T03Bowlfull23() {
        int[] bowls = { 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3 };
        int[] expectedScores = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

    [Test]
    public void T04BowlStrikeAnd23Gives15And5() {
        int[] bowls = { 10, 2, 3 };
        int[] expectedScores = { 15, 5 };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

    [Test]
    public void T05BowlSpareAnd23Gives12And5() {
        int[] bowls = { 9, 1, 2, 3 };
        int[] expectedScores = { 12, 5 };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

    [Test]
    public void T06BowlStrikeStrike23() {
        int[] bowls = { 10, 10, 2, 3 };
        int[] expectedScores = { 22, 15, 5 };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

    [Test]
    public void T07BowlStrikeGivesNothing() {
        int[] bowls = { 10 };
        int[] expectedScores = { };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

    [Test]
    public void T08BowlSpareStrike23() {
        int[] bowls = { 9, 1, 10, 2, 3 };
        int[] expectedScores = { 20, 15, 5 };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

    [Test]
    public void T09FullGameOfStrikes() {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        int[] expectedScores = { 30, 30, 30, 30, 30, 30, 30, 30, 30, 30 };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

    [Test]
    public void T09FullGameOfStrikesExceptExtraThrows() {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 2, 3 };
        int[] expectedScores = { 30, 30, 30, 30, 30, 30, 30, 30, 22, 15 };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

    [Test]
    public void T10FullGameOfStrikesLastFrameSpare() {
        int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 9, 1, 2};
        int[] expectedScores = { 30, 30, 30, 30, 30, 30, 30, 29, 20, 12 };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

    [Test]
    public void T11VerificationGame01() {
        int[] bowls = { 10, 10, 9, 0, 10, 7, 3, 10, 8, 1, 6, 3, 6, 2, 9, 1, 10 };
        int[] expectedScores = { 29, 19, 9, 20, 20, 19, 9, 9, 8, 20 };
        Assert.AreEqual(expectedScores, ScoreMaster.FrameScores(bowls.ToList()));
    }

}
