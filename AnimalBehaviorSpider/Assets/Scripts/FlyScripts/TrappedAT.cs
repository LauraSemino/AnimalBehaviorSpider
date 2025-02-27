using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class TrappedAT : ActionTask {

		public BBParameter<float> webAmount;
		public BBParameter<GameObject> flyBod;
		public BBParameter<GameObject> flyWings;
		public BBParameter<GameObject> flyWrapped;

		
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            //EndAction(true);
            //webAmount = 0;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			if (webAmount.value >= 100)
			{	
				webAmount.value = 0;
				
                flyBod.value.GetComponent<MeshRenderer>().enabled = false;
                flyWings.value.GetComponent<MeshRenderer>().enabled = false;
                flyWrapped.value.GetComponent<MeshRenderer>().enabled = true;
               
                
                EndAction(true);
            }
			

		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}