using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EatAT : ActionTask
    {
        public BBParameter<GameObject> targetWeb;
        public BBParameter<TextMeshPro> webPrompt;
        Blackboard flyBoard;
        public float webNum;
        public float actSpeed;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            flyBoard = targetWeb.value.GetComponent<Blackboard>();
            webNum = flyBoard.GetVariableValue<float>("webAmount");
            //EndAction(true);
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            
            webPrompt.value.transform.position = new Vector3(1, 1, 2);
            if (Input.GetKey(KeyCode.E))
            {
                webPrompt.value.text = ("Eating: " + Mathf.RoundToInt(webNum) + "/" + 100);
                webNum += actSpeed * Time.deltaTime;
            }
            else
            {
                webPrompt.value.text = ("Hold E to Eat");
            }

            if (webNum >= 100)
            {
                webPrompt.value.transform.position = new Vector3(1, 0, 2);
                flyBoard.SetVariableValue("webAmount", webNum);
                EndAction(true);
            }
        }

        //Called when the task is disabled.
        protected override void OnStop()
        {

        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}