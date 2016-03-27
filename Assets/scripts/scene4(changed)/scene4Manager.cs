using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene4Manager : MonoBehaviour {
//private scene2Manager: SceneHandler;
	public GameObject SceneHandlerObj;
	public SceneHandler scene4ManagerScript;
	public Text displayedDialogue_Scene4 =  null;
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
		scene4ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene4ManagerScript.setUserVisited(2);
		scene4ManagerScript.printCurrentKillerID();
		iwithEvidence = 0;
		dialogue = new string[maxDialogueLength];
		dialogue[0] = "this is the first convo";
		dialogue[1] = "Please Add BLOOD to Evidence!";
		dialogue[2] = "this is the third convo....";

		displayDialogue();
		
	}
	
	// Update is called once per frame
	void Update () {
		//if counter reached the max dialogue length, move onto next scene
		if(i==maxDialogueLength){
			if(scene4ManagerScript.userVisited[1]){
				SceneManager.LoadScene("sceneSelection");
				Debug.Log("Current SceneInstance.userVisited[1]:  ");
				Debug.Log(scene4ManagerScript.userVisited[1]);

			}
		}
	}

	
	public void displayDialogue(){
		if(i==iwithEvidence){
			scene4ManagerScript.setEvidenceCollected("blood",2);
		}
		if(i<maxDialogueLength){
			displayedDialogue_Scene4.text = dialogue[i];
			i++;
		}
				
	}
}
