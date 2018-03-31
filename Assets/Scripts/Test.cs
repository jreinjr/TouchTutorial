using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Test : MonoBehaviour {

    public GameObject controller;
    private VRTK_ControllerReference controllerReference;
    private bool hit;
    private int dumb;

	// Use this for initialization
	void Start () {
        hit = false;
        dumb = 0;
	}
	
	// Update is called once per frame
	void Update () {
        controllerReference = VRTK_ControllerReference.GetControllerReference(controller.gameObject);
        Debug.Log(controllerReference);
   
         VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, 1f, 0.5f, 0.01f);
      
        

    }
}
