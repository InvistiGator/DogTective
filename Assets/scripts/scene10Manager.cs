using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene10Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene10ManagerScript;
	public Text displayedDialogue_Scene10 =  null;
	public Canvas scene10Canvas;
	public Canvas decisionCanvas;
	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;
	private string [] dialogue_2_3;

	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;
	private int dialogue_2_3Length;

	private int section = 1;

	private int i= 0; // a counter to iterate thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength;  // defines the length of the dialogue in this scene
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene10ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene10ManagerScript.setUserVisited(10);
		scene10ManagerScript.printCurrentKillerID();

		dialogue_1 = scene10ManagerScript.readFile("Scene10_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = scene10ManagerScript.readFile("Scene10_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = scene10ManagerScript.readFile("Scene10_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		dialogue_2_3 = scene10ManagerScript.readFile("Scene10_2_3.txt");
		dialogue_2_3Length = dialogue_2_3.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			scene10Canvas.enabled = false;
			decisionCanvas.enabled = true;
		}

	}

	
	public void displayDialogue(){
	/*	if(i<maxDialogueLength){
			displayedDialogue_Scene10.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}*/
				
	}

}
