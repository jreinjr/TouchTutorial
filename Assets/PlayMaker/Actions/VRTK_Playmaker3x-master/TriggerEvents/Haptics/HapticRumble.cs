// Custom Action by DumbGameDev
// www.dumbgamedev.com

#if VRTK_VERSION_3_2_0_OR_NEWER

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTKController")]
	[Tooltip("Trigger haptic rumble with Controller Actions Script from VRTK.")]

	public class  HapticRumble : FsmStateAction

	{
		[Tooltip("Choose which controller gameobject controller you want to rumble.")]
		public FsmGameObject controller;
		
		[Tooltip("Optionally set the controller reference for this action instead of a game object")]
		public FsmInt controllerReferenceID;

		[Tooltip("Set strength of haptic rumble between 0 and 1")]
		public FsmFloat hapticStrength;
		
		[ActionSection("Optional")]
		
		[Tooltip("Set length of haptic rumble")]
		public FsmFloat duration;
		
		[Tooltip("Set pulse interval of haptic rumble")]
		public FsmFloat pulseInterval;
		
		
		public FsmBool everyFrame;
		
		private uint _controllerReferenceID;
		private VRTK_ControllerReference controllerReference;

		public override void Reset()
		{

			hapticStrength = null;
			controllerReferenceID = null;
			controller = null;
			everyFrame = false;
			duration = new FsmFloat {UseVariable = true};
			pulseInterval = new FsmFloat {UseVariable = true};
		}
		
		public override void OnEnter()
		{
			
			if(!controller.IsNone)
			{
				controllerReference = VRTK_ControllerReference.GetControllerReference(controller.Value);
			}
			
			else
			{
				_controllerReferenceID = (uint)controllerReferenceID.Value;
				controllerReference = VRTK_ControllerReference.GetControllerReference(_controllerReferenceID);
				Debug.Log ("Has Controller ID");
			}
			
			MakeItSo();
			
			if (!everyFrame.Value)
			{
				Finish();
			}

		}
		
		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			if (controllerReference == null)
			{
				Debug.Log("You need an ID or Gameobject of the controller");
				return;
			}
			
			//if (duration.Value == null || pulseInterval.Value == null)
			if (duration.IsNone)
			
			{
				
				VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, hapticStrength.Value);
				Debug.Log("Normal Hit");
				
			}
				
			else
			{
				VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, hapticStrength.Value, duration.Value, pulseInterval.Value);
                Debug.Log("Interval and Duration");
				
			}
			
		}

	}
}
#endif