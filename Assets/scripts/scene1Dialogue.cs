using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene1Dialogue : MonoBehaviour {

	public Text displayedDialogue_Scene1 =  null;
	private string [] dialogue; 
	private int i;
	// Use this for initialization
	void Start () {
		dialogue = new string[3];
		dialogue[0] = "???: On that day - the day that would signal the start of my greatest case yet - I had been sitting in my dark office for a long while.";
		dialogue[1] = "???: It’d been some time since I’d last gotten any sort of work, and even longer since I last caught a whiff of anything big.";
		dialogue[2] = "???: All of that would soon change when that day brought me the biggest case of my career.";

		displayedDialogue_Scene1.text = dialogue[0];
		i = 1;
	}
	

	
	public void displayDialogue(){
		displayedDialogue_Scene1.text = dialogue[i];
		if(i<2){
			i++;
		}		
	}
	

	// Update is called once per frame
	void Update () {
		
	}
}
