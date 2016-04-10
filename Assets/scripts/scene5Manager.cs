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
	private string [] emotion;
	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength;  // defines the length of the dialogue in this scene

	public DougEmotionController DougEmo;
	public MorganEmotionController MorganEmo;

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
		emotion = sceneManagerScript.readEmotion("5.txt");
		maxDialogueLength = dialogue.Length;

		MorganEmo.exit();

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
			if (!emotion[i].Equals("z")){
				emotionCheck(emotion[i][0], emotion[i][1]);
			}

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

	public void emotionCheck(char who, char what){
		if (who.Equals('m')){
			if (what == 'h'){
				MorganEmo.isHappy();
			}
			else if (what == 'g'){
				MorganEmo.isAngry();
			}
			else if (what == 's'){
				MorganEmo.isSad();
			}
			else if (what == 'a'){
				MorganEmo.isAwk();
			}
			else if (what == 'u'){
				MorganEmo.isSurprised();
			}
			else if (what == 'o'){
				MorganEmo.isAnnoyed();
			}
			else if (what == 'e'){
				MorganEmo.enter();
			}
			else if (what == 'x'){
				MorganEmo.exit();
			}
			else{
				MorganEmo.isIdle();
			}
		}
		else{
			//doug
			if (what == 'h'){
				DougEmo.isHappy();
			}
			else if (what == 'g'){
				DougEmo.isAngry();
			}
			else if (what == 's'){
				DougEmo.isSad();
			}
			else if (what == 'a'){
				DougEmo.isAwk();
			}
			else if (what == 'u'){
				DougEmo.isSurprised();
			}
			else if (what == 'o'){
				DougEmo.isAnnoyed();
			}
			else if (what == 'e'){
				DougEmo.enter();
			}
			else if (what == 'x'){
				DougEmo.exit();
			}
			else{
				DougEmo.isIdle();
			}
		}
	}

}
