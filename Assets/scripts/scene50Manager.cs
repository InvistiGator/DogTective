using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene50Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene50ManagerScript;
	public Text displayedDialogue_Scene50 =  null;
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
		scene50ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene50ManagerScript.setUserVisited(50);
		scene50ManagerScript.printCurrentKillerID();
		dialogue = scene50ManagerScript.readFile("Scene50.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			StartCoroutine(scene50ManagerScript.FadeStuff(0));
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			displayedDialogue_Scene50.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
