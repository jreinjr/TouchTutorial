// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions

{
	[ActionCategory("VRTK Object")]
	[Tooltip("Toggle on and off hightlight on game objects.")]

	public class  toggleHighlightObject : FsmStateAction

{
		[RequiredField]
		//[CheckForComponent(typeof(VRTK_ObjectAppearance))] 
		[Tooltip("Game object you want to toggle highlight")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Tooltip("Set duration of transition")]
		public FsmFloat fadeDuration;

		[Tooltip("Set highlight color")]
		[UIHint(UIHint.FsmColor)]
		public FsmColor color;
	
		public FsmBool enableHighlight;

		public FsmBool everyFrame;
	
		public override void Reset()
		{

			fadeDuration = 0;
			color = Color.yellow;
			enableHighlight = true;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			//var go = Fsm.GetOwnerDefaultTarget(gameObject);
			//appearance = go.GetComponent<VRTK_ObjectAppearance>();

			highlight();

			if (!everyFrame.Value)
			{
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				highlight();
			}
		}


		void highlight()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			if(enableHighlight.Value)
			{
				VRTK_ObjectAppearance.HighlightObject(go, color.Value, fadeDuration.Value);
			}
			
			else
			{
				
				VRTK_ObjectAppearance.UnhighlightObject(go);
				
			}
		}

	}
}