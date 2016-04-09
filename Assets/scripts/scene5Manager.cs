using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene5Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio5Script audioManager;
	public Text displayedDialogue_Scene5 =  null;
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
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio5Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(5);
		sceneManagerScript.printCurrentKillerID();
		dialogue = sceneManagerScript.readFile("Scene5.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			if (sceneManagerScript.userVisited[3] && !sceneManagerScript.userVisited[4]){
				StartCoroutine(sceneManagerScript.FadeStuff(4));
			}
			else{
				StartCoroutine(sceneManagerScript.FadeStuff(6));
			}
		}

	}
	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			if (i==31) {
				audioManager.playDoorClose();
			}
			displayedDialogue_Scene5.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
