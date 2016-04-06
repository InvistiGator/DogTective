using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene1Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene1ManagerScript;
	public audio1Script audioManager;
	//public EmotionController emoCtr1;

	public Text displayedDialogue_Scene1 =  null;
	private string [] dialogue; 
	public int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	public int iwithEvidence;
	public int iwithClockTick = 15;
	public int iwithDoorOpen = 26;
	public int iwithDoorClose = 46;
	public int iwithPhoneVibrating = 48;
	public int maxDialogueLength;  // defines the length of the dialogue in this scene
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene1ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio1Script>();
		//emoCtr1 = emoCtr1.GetComponent<EmotionController>();
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
		if (i==iwithClockTick) {
			audioManager.playClockTick();
		} else if (i==iwithDoorOpen) {
			audioManager.playDoorOpen();
			//emoCtr1.triggerLaugh();
		} else if (i==iwithDoorClose) {
			audioManager.playDoorClose();
			//emoCtr1.triggerAngry();
		} else if (i==iwithPhoneVibrating) {
			audioManager.playPhoneVibrating();
			//emoCtr1.triggerIdle();
		} else if(i==maxDialogueLength+1){
		//else if(i==2){
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
