using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    
    public GameObject pinSet;

    private Pin[] pins;
    private PinCounter pinCounter;

    private void Start() {
        pins = FindObjectsOfType<Pin>();
        pinCounter = FindObjectOfType<PinCounter>();
    }

    public void SetPins(ActionMaster.BowlAction action) {

        switch (action) {
            case (ActionMaster.BowlAction.Tidy):
                TidyPins();
                break;
            case (ActionMaster.BowlAction.EndTurn):
            case (ActionMaster.BowlAction.Reset):
                RenewPins();
                pinCounter.ResetPinCount();
                break;
            case (ActionMaster.BowlAction.EndGame):
                throw new UnityException("dont know how to end game yet");
        }

    }
    
    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<Ball>()) {
            // destroy the ball??
        } else {
            Destroy(other.transform.parent.gameObject);
        }
    }

    private void TidyPins() {
        foreach (Pin pin in pins) {
            if (pin) {
                if (!pin.IsStanding()) {
                    Destroy(pin.gameObject);
                } else {
                    pin.transform.rotation = Quaternion.identity;
                }
            }
        }
        // Rearrange the left-standing pins (optional)
    }

    private void RenewPins() {
        foreach (Pin pin in pins) {
            if (pin) {
                Destroy(pin.gameObject);
            }
        }
        
        Instantiate(pinSet, new Vector3(0f, 0f, 1829f),Quaternion.identity);
        
        pins = FindObjectsOfType<Pin>();
    }

}
