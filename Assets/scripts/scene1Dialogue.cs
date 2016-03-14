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
		dialogue[0] = "this is the first convo";
		dialogue[1] = "this is the second convo....";
		dialogue[2] = "this is the third convo....";

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
