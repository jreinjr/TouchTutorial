// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Version two of this action. MaximumLength was changed from a float to a Vector2 per changes in VRTK 3.1.0

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Pointer")]
	[Tooltip("Set Bezier Pointer apperance.")]

	public class SetBezierPointerApperance : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_BezierPointerRenderer))]    
		public FsmOwnerDefault gameObject;

		public FsmVector2 maximumLength;
		public FsmInt tracerDensity;
		public FsmFloat cursorRadius;

		public FsmBool everyFrame;

		VRTK.VRTK_BezierPointerRenderer theScript;

		public override void Reset()
		{

			tracerDensity = null;
			cursorRadius = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_BezierPointerRenderer>();

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

			theScript.maximumLength = maximumLength.Value;
			theScript.tracerDensity = tracerDensity.Value;
			theScript.cursorRadius = cursorRadius.Value;
		}

	}
}
