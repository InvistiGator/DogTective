using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene16Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene16ManagerScript;
	public Text displayedDialogue_Scene16 =  null;
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
		scene16ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene16ManagerScript.setUserVisited(16);
		scene16ManagerScript.printCurrentKillerID();
		dialogue = scene16ManagerScript.readFile("Scene16.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			SceneManager.LoadScene(7);
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			displayedDialogue_Scene16.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
