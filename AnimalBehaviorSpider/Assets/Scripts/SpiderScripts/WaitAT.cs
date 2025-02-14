using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {
	
	public class WaitAT : ActionTask {
        public BBParameter<GameObject> webTR;
        public BBParameter<GameObject> webTL;
        public BBParameter<GameObject> webBR;
        public BBParameter<GameObject> webBL;

		

		public WebHealth[] webArray;
		public BBParameter<GameObject> weakLink;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			webArray = new WebHealth[4];
            //EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
            webArray[0] = webTR.value.GetComponent<WebHealth>();
            webArray[1] = webTL.value.GetComponent<WebHealth>();
            webArray[2] = webBR.value.GetComponent<WebHealth>();
            webArray[3] = webBL.value.GetComponent<WebHealth>();
            float lowestHealth = 1000f;
            for (int i = 0;i < webArray.Length-1; i++)
			{
				if (webArray[i].curHealth < lowestHealth)
				{
					//Debug.Log(i);
					lowestHealth = webArray[i].curHealth;
					weakLink.value = webArray[i].gameObject;
                }
				
			}
			if (weakLink.value.GetComponent<WebHealth>().curHealth < 100)
			{
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