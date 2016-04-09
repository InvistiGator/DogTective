using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene40Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene40ManagerScript;
	public Text displayedDialogue_Scene40 =  null;
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
		scene40ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene40ManagerScript.setUserVisited(40);
		scene40ManagerScript.printCurrentKillerID();
		dialogue = scene40ManagerScript.readFile("Scene40.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			StartCoroutine(scene40ManagerScript.FadeStuff(9));
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			displayedDialogue_Scene40.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
