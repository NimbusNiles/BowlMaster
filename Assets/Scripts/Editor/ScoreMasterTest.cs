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

}
