// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Locomotion")]
	[Tooltip("Set headset collisions events for VRTK.")]

	public class  SetHeadsetCollisionTrigger : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_HeadsetCollisionFade))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Set headset collision events.")]
		public FsmBool headsetColliding;

		public FsmBool everyFrame;

		VRTK.VRTK_HeadsetCollisionFade theScript;

		public override void Reset()
		{
			headsetColliding = false;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_HeadsetCollisionFade>();

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

			theScript.enabled = headsetColliding.Value;
		}

	}
}
