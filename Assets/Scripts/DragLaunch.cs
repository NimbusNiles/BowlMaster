using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    private Vector3 velocity;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}
	
	public void DragStart() {
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd() {
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        velocity = (dragEnd - dragStart) / (endTime - startTime);
        velocity = new Vector3(velocity.x/10, velocity.z, velocity.y);
        ball.LaunchBall(velocity);
    }
}
