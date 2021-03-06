// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Interaction")]
	[Tooltip("Get the angle of a lever with the VRTK Lever Script.")]

	public class  GetLeverAngle : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_Lever))]    
		public FsmOwnerDefault gameObject;

		[TitleAttribute("Lever Angle")]
		public FsmFloat angle;

		private	VRTK.UnityEventHelper.VRTK_Control_UnityEvents controlEvents;

		public override void Reset()
		{

			gameObject = null;
			angle = null;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			controlEvents = go.GetComponent<VRTK.UnityEventHelper.VRTK_Control_UnityEvents>();
			if (controlEvents == null)
			{
				controlEvents = go.AddComponent<VRTK.UnityEventHelper.VRTK_Control_UnityEvents>();
			}

			controlEvents.OnValueChanged.AddListener(HandleChange);

		}

		private void HandleChange(object sender, Control3DEventArgs e)
		{
			angle.Value = e.value;

		}

	}

}


