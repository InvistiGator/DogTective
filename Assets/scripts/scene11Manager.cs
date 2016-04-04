using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene11Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene11ManagerScript;
	public audio11Script audioManager;
	public Text displayedDialogue_Scene11 =  null;
	private string [] dialogue; 
	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength;  // defines the length of the dialogue in this scene
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene11ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio11Script>();
	}
	void Start () {
		scene11ManagerScript.setUserVisited(11);
		scene11ManagerScript.printCurrentKillerID();
		dialogue = scene11ManagerScript.readFile("Scene11.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			SceneManager.LoadScene(9);
		}

	}

	public void displayDialogue(){
		if(i<maxDialogueLength){
			if (i==1) {
				audioManager.playClockTicking();
			} else if (i==28) {
				audioManager.play213Various();
			} else if (i == 34) {
				audioManager.play213();
			}else if (i==36) {
				audioManager.playClick();
			}
			displayedDialogue_Scene11.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
