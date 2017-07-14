using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    
    private Rigidbody thisRigidbody;
    private AudioSource audioSource;
    private Vector3 startPosition;
    //private bool inPlay;

	// Use this for initialization
	void Start () {
        //inPlay = false;

        // Find components
        thisRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;
        
        thisRigidbody.useGravity = false;
	}

    public void LaunchBall(Vector3 velocity) {
        //inPlay = true;

        thisRigidbody.velocity = velocity;
        thisRigidbody.useGravity = true;
        audioSource.Play();
    }

    public void Reset() {
        //inPlay = false;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.angularVelocity = Vector3.zero;
        thisRigidbody.useGravity = false;
    }
}
