using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Push : Action {

	public Scanner scanner;

	public Sprite pushSpriteLeft;
	public Sprite pushSpriteRight;

	public string direction;
	
	private UnityAction pushListener;

	void OnEnable(){
		EventManager.StartListening("pushListener", pushListener);
	}

	void OnDisable(){
		EventManager.StopListening("pushListener", pushListener);
	}

	void Awake(){
		pushListener = new UnityAction(PushBox);

	}

	public void PushBox(){
		//switch(direction){
		//TODO why is this only firing to the right?
		if(direction == "LEFT"){
			//scanner.curObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
			scanner.curObject.transform.position = GameObject.Find("R_Region").transform.position;//new Vector3(-11, 4, 0);
			Debug.Log("Push Left");
		}
		//	break;

		else if(direction == "RIGHT"){
			scanner.curObject.transform.position = GameObject.Find("Y_Region").transform.position;
			Debug.Log("Push Right");
		}
		//	break;
		//default:
		//	break;
		//}
	}

	void Update(){
		if(scanner == null){
			scanner = GameObject.Find("Scanner").GetComponent<Scanner>();
		}
	}
}
