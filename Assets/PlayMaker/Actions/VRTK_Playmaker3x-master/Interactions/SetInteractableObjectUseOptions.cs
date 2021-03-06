// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Interaction")]
	[Tooltip("Sets interactable object use settings.")]

	public class  SetInteractableObjectUseOptions : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_InteractableObject))]    
		public FsmOwnerDefault gameObject;

		public FsmBool isUseable;
		public FsmBool holdButtonToUse;
		public FsmBool useOnlyIfGrabbed;
		public FsmBool pointerActivities;

		[ObjectType(typeof(VRTK.VRTK_ControllerEvents.ButtonAlias))]
		public FsmEnum useOverrideButton;

		[ObjectType(typeof(VRTK.VRTK_InteractableObject.AllowedController))]
		public FsmEnum allowedUsedController;

		public FsmBool everyFrame;

		VRTK.VRTK_InteractableObject theScript;

		public override void Reset()
		{

			isUseable = false;
			holdButtonToUse = false;
			useOnlyIfGrabbed = false;
			pointerActivities = false;
			useOverrideButton = null;
			allowedUsedController = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_InteractableObject>();

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

			theScript.isUsable = isUseable.Value;
			theScript.holdButtonToUse = holdButtonToUse.Value;
			theScript.useOnlyIfGrabbed = useOnlyIfGrabbed.Value;
			theScript.pointerActivatesUseAction = pointerActivities.Value;
			theScript.useOverrideButton = (VRTK.VRTK_ControllerEvents.ButtonAlias)useOverrideButton.Value;
			theScript.allowedUseControllers = (VRTK.VRTK_InteractableObject.AllowedController)allowedUsedController.Value;

		}

	}
} 