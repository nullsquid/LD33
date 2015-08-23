using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
public class Sequence : MonoBehaviour {

	public List<Step> steps = new List<Step>();
	public Step curStep;
	public Step selectedStep;
	public bool sequenceRunning;
	public Sprite emptyStepIdle;
	public Sprite emptyStepActive;
	public Sprite emptyStepSelected;
	public Dictionary<string, Sprite> stepSprites = new Dictionary<string, Sprite>();

	public Push pushAction;

	public GameObject nextAction;


	private UnityAction startSequence;
	private UnityAction stopSequence;

	void OnEnable(){
		EventManager.StartListening("startSequence", startSequence);
		EventManager.StartListening("stopSequence", stopSequence);
	}

	void OnDisable(){
		EventManager.StopListening("startSequence", startSequence);
		EventManager.StopListening("stopSequence", stopSequence);
	}

	void Awake(){
		startSequence = new UnityAction(StartSequence);
		stopSequence = new UnityAction(StopSequenece);
	}
	// Use this for initialization
	void Start () {
		stepSprites.Add ("emptyIdle", emptyStepIdle);
		stepSprites.Add ("emptyActive", emptyStepActive);
		stepSprites.Add ("emptySelected", emptyStepSelected);

		foreach(Transform child in transform){
			steps.Add(child.GetComponent<Step>() as Step);
		}
		for(int i = 0; i < steps.Count; i++){
			steps[i].GetComponent<SpriteRenderer>().sprite = stepSprites["emptyIdle"];
		}

		//StartSequence();
		

	}
	public void SelectStep(int stepNumber){
		for(int i = 0; i < steps.Count; i++){
			selectedStep = steps[stepNumber - 1];
			selectedStep.GetComponent<SpriteRenderer>().sprite = stepSprites["emptySelected"];
			steps[i].selected = false;
			selectedStep.selected = true;
			if(selectedStep != steps[i]){
				steps[i].GetComponent<SpriteRenderer>().sprite = stepSprites["emptyIdle"];
			}
		}

	}

	public void AddNewAction(Action newAction, string parameter){
		Action action;
		//Sprite sprite;
		if(selectedStep != null){
			if(selectedStep.transform.childCount < 1){
				action = Instantiate(newAction, transform.position, transform.rotation) as Action;
				action.transform.parent = selectedStep.transform;
				if(action == pushAction){
				Debug.Log(parameter);
					switch(parameter){
					case "RIGHT":
						action.GetComponent<Push>().direction = parameter;
						action.gameObject.GetComponent<SpriteRenderer>().sprite = action.gameObject.GetComponent<Push>().pushSpriteRight;
						break;
					}
				}
			}
			else if(selectedStep.transform.childCount <= 1){
				foreach(Transform child in selectedStep.transform){
					//if(child.GetComponent<Push>() is Action){
					GameObject newChild = FindObjectOfType(typeof (Action)) as GameObject;
					/*if(child.GetComponent<GameObject> = newChild){

					Destroy(child.GetComponent<GameObject>(), 0);
					}//}
					*/
				}

				action = Instantiate(newAction, transform.position, transform.rotation) as Action;
				action.transform.parent = selectedStep.transform;
				action.transform.localPosition = Vector3.zero;
				//sprite = ;
					switch(parameter){
					case "RIGHT":
						action.GetComponent<Push>().direction = parameter;

						action.GetComponent<SpriteRenderer>().sprite = action.GetComponent<Push>().pushSpriteRight;
						break;
					case "LEFT":
						action.GetComponent<Push>().direction = parameter;
						action.GetComponent<SpriteRenderer>().sprite = action.GetComponent<Push>().pushSpriteLeft;
						break;

					}

			}

		}
	}
	public void AddNewCondition(Condition newCondition){

	}
	public void StartSequence(){
		sequenceRunning = true;
		StartCoroutine("SequenceRunning");
	}

	public void StopSequenece(){
		sequenceRunning = false;
		StopCoroutine("SequenceRunning");
	}
	IEnumerator SequenceRunning(){
		while (sequenceRunning == true){


			for (int i = 0; i < steps.Count; i++){
				Debug.Log (i);
				steps[i].GetComponent<SpriteRenderer>().sprite = stepSprites["emptyIdle"];
				curStep = steps[i];
				foreach(Transform child in curStep.transform){
					if(child.GetComponent<Push>() != null){
						//nextAction = child.GetComponent<GameObject>();
						//nextAction.GetComponent<Push>().PushBox("LEFT");
						EventManager.TriggerEvent("pushListener");
					}
				}
				if(curStep.GetComponent<SpriteRenderer>().sprite == stepSprites["emptyIdle"]){

					curStep.GetComponent<SpriteRenderer>().sprite = stepSprites["emptyActive"];

				}




				if(i > steps.Count){
					i = 0;


				}

				yield return new WaitForSeconds(1);
			}

		}
	}
}
