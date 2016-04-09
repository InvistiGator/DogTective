using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene25Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio25Script audioManager;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;
	private string [] dialogue_2;

	private int dialogue_1Length;
	private int dialogue_2Length;

	private int section = 1;

	private int i = 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio25Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(25);
		sceneManagerScript.printCurrentKillerID();
		
		dialogue_1 = sceneManagerScript.readFile("Scene25_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2 = sceneManagerScript.readFile("Scene25_2.txt");
		dialogue_2Length = dialogue_2.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			if (!sceneManagerScript.lookForEvidence("tie") && sceneManagerScript.userVisited[23]){
				i = 0;
				section = 2;
				displayDialogue();
			}
			else{
				StartCoroutine(sceneManagerScript.FadeStuff(9));
			}
		}
		else if (section == 2 && i == dialogue_2Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(26));
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			if (i==9) {
				audioManager.playKnocking();
			} else if (i==13) {
				audioManager.playDoorOpen();
			} else if (i==28) {
				audioManager.playDoorClose();
			}
			displayedDialogue.text = dialogue_1[i];
			i++;
		}
		else if(section == 2 && i < dialogue_2Length){
			displayedDialogue.text = dialogue_2[i];
			i++;
		}
		else{
			i++;
		}		
	}
}
