using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Security.Cryptography;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class FlyAT : ActionTask {

		public float speed;
		public float ranHeight;

		public float spawnTimer;

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

            flyBod.value.GetComponent<MeshRenderer>().enabled = true;
            flyWings.value.GetComponent<MeshRenderer>().enabled = true;
            flyWrapped.value.GetComponent<MeshRenderer>().enabled = false;



            spawnTimer = UnityEngine.Random.Range(2f, 10f);
            ranHeight = UnityEngine.Random.Range(-4f, 4f);
            agent.transform.position = new Vector3(-15, 0, ranHeight);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			spawnTimer -= Time.deltaTime;
			if (spawnTimer <= 0)
			{
                Vector3 pos;
                pos = agent.transform.position;
                pos.x += speed * Time.deltaTime;
                agent.transform.position = pos;
                if (agent.transform.position.x >= 0f)
                {
                    EndAction(true);
                }
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