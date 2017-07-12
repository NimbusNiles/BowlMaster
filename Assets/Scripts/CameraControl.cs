using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Ball ball;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<Ball>();

        offset = transform.position - ball.transform.position;
	}

	// Update is called once per frame
	void Update () {
        if (ball.transform.position.z >= 1700) {
            return;
        }

        transform.position = ball.transform.position + offset;
	}
}
