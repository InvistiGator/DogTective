using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene35Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene35ManagerScript;
	public Text displayedDialogue_Scene35 =  null;
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
		scene35ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene35ManagerScript.setUserVisited(35);
		scene35ManagerScript.printCurrentKillerID();
		dialogue = scene35ManagerScript.readFile("Scene35.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			StartCoroutine(scene35ManagerScript.FadeStuff(0));
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			displayedDialogue_Scene35.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
