using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Drill : VRTK_InteractableObject {

    [Range(0, 1)]
    public float drillSpeed;

    public float maxSpeed;

    GameObject spinPart;
    GameObject trigger;
    float triggerPos;

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        usingObject.controllerEvents.TriggerAxisChanged += new ControllerInteractionEventHandler(DoTriggerAxisChanged);
    }

    private void DoTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
    {
        drillSpeed = e.buttonPressure;
        Debug.Log(drillSpeed);
    }

    public override void StopUsing(VRTK_InteractUse usingObject)
    {
        base.StopUsing(usingObject);
        drillSpeed = 0f;
        usingObject.controllerEvents.TriggerAxisChanged -= DoTriggerAxisChanged;
    }


    // Use this for initialization
    void Start () {
        spinPart = GameObject.Find("Spin");
        trigger = GameObject.Find("Trigger");
        triggerPos = trigger.transform.localPosition.x;
    }
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        spinPart.transform.Rotate(new Vector3(drillSpeed * maxSpeed, 0, 0));
        trigger.transform.localPosition = new Vector3(Mathf.Lerp(triggerPos, triggerPos - 0.1f, drillSpeed), trigger.transform.localPosition.y, trigger.transform.localPosition.z);
        
	}
}
