using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
public class SequenceController : MonoBehaviour {

	public List<Sequence> sequences = new List<Sequence>();
	// Use this for initialization
	void Start () {
		foreach(Transform child in transform){
			if(child.GetComponent<Sequence>() is Sequence){
				sequences.Add (child.GetComponent<Sequence>() as Sequence);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
