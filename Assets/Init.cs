using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Init : MonoBehaviour {

    public List<Box> boxes = new List<Box>();
	public Sprite redBox;
	public Sprite yellowBox;
	public Dictionary<string, Sprite> objectSprites = new Dictionary<string, Sprite>();
	public int numberOfBoxes;
	public Box boxPrefab;

	// Use this for initialization
	void Start () {
		objectSprites.Add ("redBox", redBox);
		objectSprites.Add ("yellowBox", yellowBox);

		/*for(int i = 0; i <= numberOfBoxes; i++){
			StartCoroutine("AssembleBox");

		}*/
		StartCoroutine("SpawnBox");
	}


	IEnumerator AssembleBox(){
		Box newBox = boxPrefab;
		int randomBoxNumber = Random.Range (1, 3);
		Debug.Log(randomBoxNumber);
		if(randomBoxNumber == 1){
			newBox.GetComponent<SpriteRenderer>().sprite = objectSprites["redBox"];
			newBox.color = "red";
		}
		else if (randomBoxNumber == 2){
			newBox.GetComponent<SpriteRenderer>().sprite = objectSprites["yellowBox"];
			newBox.color = "yellow";
		}
		boxes.Add (newBox);
		Instantiate(newBox, transform.position, transform.rotation);
		yield return new WaitForSeconds(0.5f);


	}
	IEnumerator SpawnBox(){
		for(int i = 0; i <= numberOfBoxes; i++){
			StartCoroutine("AssembleBox");
			yield return new WaitForSeconds(.5f);
    	}
	}
}
