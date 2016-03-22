using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene3Manager : MonoBehaviour {
//private scene2Manager: SceneHandler;
	public GameObject SceneHandlerObj;
	public SceneHandler scene3ManagerScript;
	public Text displayedDialogue_Scene3 =  null;
	public Canvas scene3Canvas;
	//different dialogue versions in this scenes based on the random killerID generated in sceneHandler
	private string [] dialogue;

	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength = 3;  // defines the length of the dialogue in this scene
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene3ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene3ManagerScript.setUserVisited(3);
		scene3ManagerScript.printCurrentKillerID();
		iwithEvidence = 1;		
		//set up dialogue needed for this scene
		setUpDialogue();
		displayDialogue();
		
		//disable GUI at beginning 
		scene3Canvas = scene3Canvas.GetComponent<Canvas> (); 
		scene3Canvas.enabled = true; 
	}
	
	// Update is called once per frame
	void Update () {
		//if counter reached the max dialogue length, move onto next scene
		if(i==maxDialogueLength){
			//if before this scene something already visited somewhere direct as needed
			if(scene3ManagerScript.userVisited[2]){
				SceneManager.LoadScene(4);
				Debug.Log("Current SceneInstance.userVisited[3]:  ");
				Debug.Log(scene3ManagerScript.userVisited[3]);

			}
		}
	}

	public void setUpDialogue() {
		dialogue = new string[maxDialogueLength];
		dialogue[0] = "this is the first convo from scene 3";
		dialogue[1] = "dfdfafdde!";
		dialogue[2] = "this is the third convo....";
		//change dialogue base on random variables
		changeDialogue(); 
	}
	public void changeDialogue(){
		//write switch or if/else statements to decide what portion of dialogue need to be changed. 
		//if(scene3ManagerScript.killerID == 0 )
		//	dialogue[3] = "hummmm...is Doug the killer?"
	}
	public void displayDialogue(){
		if(i==iwithEvidence){
			scene3ManagerScript.setEvidenceCollected("evidence",3);
		}
		if(i<maxDialogueLength){
			displayedDialogue_Scene3.text = dialogue[i];
			i++;
		}
				
	}

	public void enableGUI(){
		scene3Canvas.enabled = true;
	}
}
