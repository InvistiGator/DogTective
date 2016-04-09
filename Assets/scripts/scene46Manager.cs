using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene46Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene46ManagerScript;
	public Text displayedDialogue_Scene46 =  null;
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
		scene46ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene46ManagerScript.setUserVisited(46);
		scene46ManagerScript.printCurrentKillerID();
		dialogue = scene46ManagerScript.readFile("Scene46.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			StartCoroutine(scene46ManagerScript.FadeStuff(0));
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			displayedDialogue_Scene46.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
