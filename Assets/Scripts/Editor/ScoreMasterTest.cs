using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScoreMasterTest : MonoBehaviour {

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

}
