using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class FixAT : ActionTask {

        public BBParameter<GameObject> targetFix;
		public BBParameter<TextMeshPro> inputPrompt;
		public float fixSpeed;
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
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			inputPrompt.value.transform.position = new Vector3(1,1,2);
			if (Input.GetKey(KeyCode.Space))
			{
                targetFix.value.GetComponent<WebHealth>().curHealth += fixSpeed * Time.deltaTime;
                inputPrompt.value.text = ("Web Health: " + Mathf.RoundToInt(targetFix.value.GetComponent<WebHealth>().curHealth) + "/" + targetFix.value.GetComponent<WebHealth>().maxHealth);
            }
			else
			{
                inputPrompt.value.text = ("Hold Space to Fix");
            }
			
			if (targetFix.value.GetComponent<WebHealth>().curHealth >= targetFix.value.GetComponent<WebHealth>().maxHealth)
			{
				targetFix.value.GetComponent<WebHealth>().webWeaken = false;
				inputPrompt.value.transform.position = new Vector3(1, 0, 2);
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