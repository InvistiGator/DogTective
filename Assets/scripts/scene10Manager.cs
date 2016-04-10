using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene10Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio10Script audioManager;
	public Text displayedDialogue_Scene10 =  null;
	public Canvas scene10Canvas;
	public Canvas decisionCanvas;
	public SpriteRenderer bar5;
	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;
	private string [] dialogue_2_3;

	private string [] emotion_1;
	private string [] emotion_2_1;
	private string [] emotion_2_2;
	private string [] emotion_2_3;

	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;
	private int dialogue_2_3Length;

	private int section = 1;

	public DougEmotionController DougEmo;
	public JadeEmotionController JadeEmo;
	public TomEmotionController TomEmo;

	private int i= 0; // a counter to iterate thru conversations, and set important convo indexes
	private int iwithEvidence;

	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio10Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(10);
		sceneManagerScript.printCurrentKillerID();

		dialogue_1 = sceneManagerScript.readFile("Scene10_1.txt");
		emotion_1 = sceneManagerScript.readEmotion("10_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = sceneManagerScript.readFile("Scene10_2_1.txt");
		emotion_2_1 = sceneManagerScript.readEmotion("10_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = sceneManagerScript.readFile("Scene10_2_2.txt");
		emotion_2_2 = sceneManagerScript.readEmotion("10_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		dialogue_2_3 = sceneManagerScript.readFile("Scene10_2_3.txt");
		emotion_2_3 = sceneManagerScript.readEmotion("10_2_3.txt");
		dialogue_2_3Length = dialogue_2_3.Length;

		TomEmo.exit();

		scene10Canvas = scene10Canvas.GetComponent<Canvas> (); 
		scene10Canvas.enabled = true; 
		decisionCanvas = decisionCanvas.GetComponent<Canvas>();
		decisionCanvas.enabled = false;

		bar5 = bar5.GetComponent<SpriteRenderer>();

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			scene10Canvas.enabled = false;
			decisionCanvas.enabled = true;
		}
		else if (section == 21 && i == dialogue_2_1Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(11));
		}
		else if (section == 22 && i == dialogue_2_2Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(10));
		}
		else if (section == 23 && i == dialogue_2_3Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
	}

	public void choice1(){
		i = 0;
		section = 21;
		displayDialogue();
		decisionCanvas.enabled = false;
		scene10Canvas.enabled = true;
	}

	public void choice2(){
		i = 0;
		section = 22;
		displayDialogue();
		decisionCanvas.enabled = false;
		scene10Canvas.enabled = true;
	}

	public void choice3(){
		i = 0;
		section = 23;
		displayDialogue();
		decisionCanvas.enabled = false;
		scene10Canvas.enabled = true;
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			if (!emotion_1[i].Equals("z")){
				emotionCheck(emotion_1[i][0], emotion_1[i][1]);
			}

			if (i==28){
				bar5.enabled = false;
			}

			if (i==38) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue_Scene10.text = dialogue_1[i];
			i++;
		}
		else if (section == 21 && i < dialogue_2_1Length){
			if (!emotion_2_1[i].Equals("z")){
				emotionCheck(emotion_2_1[i][0], emotion_2_1[i][1]);
			}

			if (i == 0) {
				audioManager.playDecisionResolution();
			}
			displayedDialogue_Scene10.text = dialogue_2_1[i];
			i++;
		}
		else if (section == 22 && i < dialogue_2_2Length){
			if (!emotion_2_2[i].Equals("z")){
				emotionCheck(emotion_2_2[i][0], emotion_2_2[i][1]);
			}

			if (i == 0) {
				audioManager.playDecisionResolution();
			}
			if (i==10) {
				audioManager.playClockTicking();
			} else if (i==15) {
				audioManager.playDoorOpen();
			}
			displayedDialogue_Scene10.text = dialogue_2_2[i];
			i++;
		}
		else if (section == 23 && i < dialogue_2_3Length){
			if (!emotion_2_3[i].Equals("z")){
				emotionCheck(emotion_2_3[i][0], emotion_2_3[i][1]);
			}

			if (i == 0) {
				audioManager.playDecisionResolution();
			}
			displayedDialogue_Scene10.text = dialogue_2_3[i];
			i++;
		}
		else{
			i++;
		}
				
	}

	public void emotionCheck(char who, char what){
		if (who.Equals('j')){
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
		else if (who.Equals('a')){
			DougEmo.exit();
			TomEmo.exit();
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
