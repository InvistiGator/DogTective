using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene1Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio1Script audioManager;
	//public EmotionController emoCtr1;

	public Text displayedDialogue_Scene1 =  null;
	private string [] dialogue; 
	private string [] emotion;
	public int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	public int iwithEvidence;
	public int iwithClockTick = 15;
	public int iwithDoorOpen = 26;
	public int iwithDoorClose = 46;
	public int iwithPhoneVibrating = 48;
	public int maxDialogueLength;  // defines the length of the dialogue in this scene
	
	public DougEmotionController DougEmo;
	public DaminaEmotionController DaminaEmo;

	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio1Script>();
		//emoCtr1 = emoCtr1.GetComponent<EmotionController>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(1);
		sceneManagerScript.printCurrentKillerID();
		dialogue = sceneManagerScript.readFile("Scene1.txt");
		emotion = sceneManagerScript.readEmotion("1.txt");
		maxDialogueLength = dialogue.Length;

		DaminaEmo.exit();


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
		} //else if(i==maxDialogueLength+1){
		else if(i==2){
			StartCoroutine(sceneManagerScript.FadeStuff(16));
		}
	}

	public void displayDialogue(){
		if(i<maxDialogueLength){
			if (!emotion[i].Equals("z")){
				emotionCheck(emotion[i][0], emotion[i][1]);
			}

			displayedDialogue_Scene1.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}			
	}

	public void emotionCheck(char who, char what){
		if (who.Equals('c')){
			if (what == 'h'){
				DaminaEmo.isHappy();
			}
			else if (what == 'g'){
				DaminaEmo.isAngry();
			}
			else if (what == 's'){
				DaminaEmo.isSad();
			}
			else if (what == 'a'){
				DaminaEmo.isAwk();
			}
			else if (what == 'u'){
				DaminaEmo.isSurprised();
			}
			else if (what == 'o'){
				DaminaEmo.isAnnoyed();
			}
			else if (what == 'e'){
				DaminaEmo.enter();
			}
			else if (what == 'x'){
				DaminaEmo.exit();
			}
			else{
				DaminaEmo.isIdle();
			}
		}
		/*else if (who.Equals('j')){
			if (what == 'h'){
				JadeEmo.isHappy();
			}
			else if (what == 'g'){
				JadeEmo.isAngry();
			}
			else if (what == 's'){
				JadeEmo.isSad();
			}
			else if (what == 'a'){
				JadeEmo.isAwk();
			}
			else if (what == 'u'){
				JadeEmo.isSurprised();
			}
			else if (what == 'o'){
				JadeEmo.isAnnoyed();
			}
			else if (what == 'e'){
				JadeEmo.enter();
			}
			else if (what == 'x'){
				JadeEmo.exit();
			}
			else{
				JadeEmo.isIdle();
			}
		}
		else if (who.Equals('n')){
			if (what == 'h'){
				NormEmo.isHappy();
			}
			else if (what == 'g'){
				NormEmo.isAngry();
			}
			else if (what == 's'){
				NormEmo.isSad();
			}
			else if (what == 'a'){
				NormEmo.isAwk();
			}
			else if (what == 'u'){
				NormEmo.isSurprised();
			}
			else if (what == 'o'){
				NormEmo.isAnnoyed();
			}
			else if (what == 'e'){
				NormEmo.enter();
			}
			else if (what == 'x'){
				NormEmo.exit();
			}
			else{
				NormEmo.isIdle();
			}
		}
		else if (who.Equals('t')){
			if (what == 'h'){
				TomEmo.isHappy();
			}
			else if (what == 'g'){
				TomEmo.isAngry();
			}
			else if (what == 's'){
				TomEmo.isSad();
			}
			else if (what == 'a'){
				TomEmo.isAwk();
			}
			else if (what == 'u'){
				TomEmo.isSurprised();
			}
			else if (what == 'o'){
				TomEmo.isAnnoyed();
			}
			else if (what == 'e'){
				TomEmo.enter();
			}
			else if (what == 'x'){
				TomEmo.exit();
			}
			else{
				TomEmo.isIdle();
			}
		}
		else if (who.Equals('g')){
			if (what == 'h'){
				GoldieEmo.isHappy();
			}
			else if (what == 'g'){
				GoldieEmo.isAngry();
			}
			else if (what == 's'){
				GoldieEmo.isSad();
			}
			else if (what == 'a'){
				GoldieEmo.isAwk();
			}
			else if (what == 'u'){
				GoldieEmo.isSurprised();
			}
			else if (what == 'o'){
				GoldieEmo.isAnnoyed();
			}
			else if (what == 'e'){
				GoldieEmo.enter();
			}
			else if (what == 'x'){
				GoldieEmo.exit();
			}
			else{
				GoldieEmo.isIdle();
			}
		}
		else if (who.Equals('m')){
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
		else if (who.Equals('a')){
			DougEmo.exit();
			JadeEmo.exit();
			NormEmo.exit();
			DaminaEmo.exit();
			TomEmo.exit();
			GoldieEmo.exit();
			MorganEmo.exit();
		}*/
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
