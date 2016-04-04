using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene1Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene1ManagerScript;
	public Text displayedDialogue_Scene1 =  null;
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
		scene1ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene1ManagerScript.setUserVisited(1);
		scene1ManagerScript.printCurrentKillerID();
		dialogue = scene1ManagerScript.readFile("Scene1.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
		//if(i==2){
			SceneManager.LoadScene(2);
		}
	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			displayedDialogue_Scene1.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
