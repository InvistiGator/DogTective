using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene28Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio28Script audioManager;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;
	private string [] dialogue_2;
	private string [] dialogue_3;

	private string [] emotion_1;
	private string [] emotion_2;
	private string [] emotion_3;

	private int dialogue_1Length;
	private int dialogue_2Length;
	private int dialogue_3Length;

	private int section = 1;

	public DougEmotionController DougEmo;
	public JadeEmotionController JadeEmo;
	public MorganEmotionController MorganEmo;

	public Canvas sceneCanvas;
	public Canvas decision1Canvas;

	private int i = 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio28Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(28);
		sceneManagerScript.printCurrentKillerID();

		if (!sceneManagerScript.lookForEvidence("tie") && sceneManagerScript.userVisited[23]){
			section = 1;
		}
		else{
			section = 3;
		}
		
		dialogue_1 = sceneManagerScript.readFile("Scene28_1.txt");
		emotion_1 = sceneManagerScript.readEmotion("28_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2 = sceneManagerScript.readFile("Scene28_2.txt");
		emotion_2 = sceneManagerScript.readEmotion("28_2.txt");
		dialogue_2Length = dialogue_2.Length;

		dialogue_3 = sceneManagerScript.readFile("Scene28_3.txt");
		emotion_3 = sceneManagerScript.readEmotion("28_3.txt");
		dialogue_3Length = dialogue_3.Length;

		MorganEmo.exit();

		displayDialogue();

		sceneCanvas = sceneCanvas.GetComponent<Canvas>(); 
		sceneCanvas.enabled = true; 
		decision1Canvas = decision1Canvas.GetComponent<Canvas>();
		decision1Canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			sceneCanvas.enabled = false;
			decision1Canvas.enabled = true;
		}
		else if (section == 2 && i == dialogue_2Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
		else if (section == 3 && i == dialogue_3Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			if (!emotion_1[i].Equals("z")){
				emotionCheck(emotion_1[i][0], emotion_1[i][1]);
			}

			if (i==1) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue.text = dialogue_1[i];
			i++;
		}
		else if(section == 2 && i < dialogue_2Length){
			if (!emotion_2[i].Equals("z")){
				emotionCheck(emotion_2[i][0], emotion_2[i][1]);
			}

			if (i==0) {
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_2[i];
			i++;
		}
		else if(section == 3 && i < dialogue_3Length){
			if (!emotion_3[i].Equals("z")){
				emotionCheck(emotion_3[i][0], emotion_3[i][1]);
			}

			displayedDialogue.text = dialogue_3[i];
			i++;
		}
		else{
			i++;
		}		
	}

	public void decision1(){
		i = 0;
		section = 2;
		displayDialogue();
		decision1Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision2(){
		i = 0;
		audioManager.playDecisionRes();
		StartCoroutine(sceneManagerScript.FadeStuff(9));
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
