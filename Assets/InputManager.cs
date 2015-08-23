using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class InputManager : MonoBehaviour {
	bool returnToggled = false;
	bool canControl = true;
	public SequenceController sController;
	public Sequence commandSequence;
	//int numberCommand;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(returnToggled == false){
			if(Input.GetKeyDown(KeyCode.Return)){
				EventManager.TriggerEvent("startSequence");
				returnToggled = true;
				canControl = false;
			}
		}
		else if(returnToggled == true){
			if(Input.GetKeyDown(KeyCode.Return)){
				EventManager.TriggerEvent("stopSequence");
				returnToggled = false;
				canControl = true;
			}

		}
		if(canControl == true){
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				SelectStep(1);
			}
			else if(Input.GetKeyDown(KeyCode.Alpha2)){
				SelectStep(2);
			}
			else if(Input.GetKeyDown(KeyCode.Alpha3)){
				SelectStep(3);
			}
			else if(Input.GetKeyDown(KeyCode.Alpha4)){
				SelectStep(4);
			}
			else if(Input.GetKeyDown(KeyCode.Alpha5)){
				SelectStep(5);
			}
			else if(Input.GetKeyDown(KeyCode.Alpha6)){
				SelectStep(6);
			}

			if(Input.GetKeyDown(KeyCode.RightArrow)){
				AddToStep("RIGHT");
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow)){
				AddToStep("LEFT");
			}
		}
	}

	void SelectStep(int stepNumber){
		commandSequence.SelectStep(stepNumber);
	}

	void AddToStep(string command){
		switch(command){
		case "RIGHT":
			commandSequence.AddNewAction(commandSequence.pushAction, command);

			break;
		case "LEFT":
			commandSequence.AddNewAction(commandSequence.pushAction, command);

			break;
		}
	}
}
