using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

namespace NodeCanvas.Tasks.Actions {

	public class SearchAT : ActionTask {
		public BBParameter<GameObject> targetFix;
        private NavMeshAgent navAgent;
		public Vector3 distance;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
            navAgent = agent.GetComponent<NavMeshAgent>();
            NavMeshHit navMeshHit;
            NavMesh.SamplePosition(targetFix.value.transform.position, out navMeshHit, 50, NavMesh.AllAreas);
            navAgent.SetDestination(navMeshHit.position);
            //EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			distance = agent.transform.position - targetFix.value.transform.position;
			if (distance.magnitude < 1)
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