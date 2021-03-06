// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions

#if VRTK_VERSION_3_2_0_OR_NEWER

{
	[ActionCategory("VRTKController")]
	[Tooltip("Get controller velocity.")]

	public class  getControllerVelocity : FsmStateAction

	{
		[Tooltip("Choose which controller gameobject controller you want to rumble.")]
		public FsmGameObject controller;

		[Tooltip("Optionally set the controller reference for this action instead of a game object")]
		public FsmInt controllerReferenceID;

		[UIHint(UIHint.Variable)]
		public FsmVector3 controllerVelocity;

		[UIHint(UIHint.Variable)]
		public FsmVector3 VelocityNormalized;

		[UIHint(UIHint.Variable)]
		public FsmFloat Magnitiude;

		public FsmBool everyFrame;

		private uint _controllerReferenceID;
		private VRTK_ControllerReference controllerReference;

		public override void Reset()
		{

			controllerVelocity = null;
			controllerReferenceID = null;
			VelocityNormalized = null;
			controller = null;
			everyFrame = false;
			Magnitiude = null;
		}

		public override void OnEnter()
		{

			// Get Controller Reference or ID
			if(!controller.IsNone)
			{
				controllerReference = VRTK_ControllerReference.GetControllerReference(controller.Value);
			}

			else
			{
				_controllerReferenceID = (uint)controllerReferenceID.Value;
				controllerReference = VRTK_ControllerReference.GetControllerReference(_controllerReferenceID);
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

			controllerVelocity.Value = VRTK_DeviceFinder.GetControllerVelocity (controllerReference);
			VelocityNormalized.Value = controllerVelocity.Value.normalized;
			Magnitiude.Value = controllerVelocity.Value.magnitude;

		}

	}
}

#else

{
[ActionCategory("VRTKController")]
[Tooltip("Get controller velocity.")]

public class  getControllerVelocity : FsmStateAction

{
[RequiredField]
public FsmOwnerDefault gameObject;
[UIHint(UIHint.Variable)]
public FsmVector3 controllerVelocity;
[UIHint(UIHint.Variable)]
public FsmVector3 VelocityNormalized;
[UIHint(UIHint.Variable)]
public FsmFloat Magnitiude;
public FsmBool everyFrame;

public override void Reset()
{

controllerVelocity = null;
VelocityNormalized = null;
gameObject = null;
everyFrame = false;
Magnitiude = null;
}

public override void OnEnter()
{
var go = Fsm.GetOwnerDefaultTarget(gameObject);

if (!everyFrame.Value)
{
MakeItSo();
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
var go = Fsm.GetOwnerDefaultTarget(gameObject);
if (go == null)
{
return;
}

controllerVelocity.Value = VRTK.VRTK_DeviceFinder.GetControllerVelocity(go);
VelocityNormalized.Value = controllerVelocity.Value.normalized;
Magnitiude.Value = controllerVelocity.Value.magnitude;

}

}
}

#endif