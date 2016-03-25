using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene2Manager : MonoBehaviour {
//private scene2Manager: SceneHandler;
	public GameObject SceneHandlerObj;
	public SceneHandler scene2ManagerScript;
	public Text displayedDialogue_Scene2 =  null;
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
		scene2ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene2ManagerScript.setUserVisited(2);
		scene2ManagerScript.printCurrentKillerID();
		iwithEvidence = 0;
		dialogue = new string[maxDialogueLength];
		dialogue[0] = "this is the first convo of scene2";
		dialogue[1] = "Please Add BLOOD to Evidence!";
		dialogue[2] = "this is the third convo....";

		displayDialogue();
		
	}
	
	// Update is called once per frame
	void Update () {
		//if counter reached the max dialogue length, move onto next scene
		if(i==maxDialogueLength){
			if(scene2ManagerScript.userVisited[1]){
				SceneManager.LoadScene(3);
				Debug.Log("Current SceneInstance.userVisited[1]:  ");
				Debug.Log(scene2ManagerScript.userVisited[1]);

			}
		}
	}

	
	public void displayDialogue(){
		if(i==iwithEvidence){
			scene2ManagerScript.setEvidenceCollected("blood",2);
		}
		if(i<maxDialogueLength){
			displayedDialogue_Scene2.text = dialogue[i];
			i++;
		}
				
	}
}
