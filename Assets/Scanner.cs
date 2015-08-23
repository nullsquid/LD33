using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Scanner : MonoBehaviour {

	public Collider2D curObject;

	private UnityAction sendBox;

	void OnEnable(){
		EventManager.StartListening("sendBox", sendBox);
	}

	void OnDisable(){
		EventManager.StopListening("sendBox", sendBox);
	}

	void Awake(){
		sendBox = new UnityAction(SendBoxInfo);
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log(other);
		if(other.tag == "Box"){
			curObject = other;
		}
	}

	public void SendBoxInfo(){


	}

	void Update(){

	}
}
