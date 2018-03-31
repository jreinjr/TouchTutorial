using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRTK_ControllerEventTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<VRTK_ControllerEvents>().TriggerPressed += DoTriggerPressed;
	}

    void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("TRIGGER");
    }

}
