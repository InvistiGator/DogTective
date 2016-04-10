using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene16Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio16Script audioManager;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;
	private string [] dialogue_3_1;
	private string [] dialogue_3_2;
	private string [] dialogue_4;

	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;
	private int dialogue_3_1Length;
	private int dialogue_3_2Length;
	private int dialogue_4Length;

	private string [] emotion_1;
	private string [] emotion_2_1;
	private string [] emotion_2_2;
	private string [] emotion_3_1;
	private string [] emotion_3_2;
	private string [] emotion_4;

	private int section = 1;

	public DougEmotionController DougEmo;
	public JadeEmotionController JadeEmo;
	public TomEmotionController TomEmo;

	public Canvas sceneCanvas;
	public Canvas decision1Canvas;
	public Canvas decision2Canvas;

	private int i = 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;

	// initialization
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio16Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(16);
		sceneManagerScript.printCurrentKillerID();
		
		dialogue_1 = sceneManagerScript.readFile("Scene16_1.txt");
		emotion_1 = sceneManagerScript.readEmotion("16_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = sceneManagerScript.readFile("Scene16_2_1.txt");
		emotion_2_1 = sceneManagerScript.readEmotion("16_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = sceneManagerScript.readFile("Scene16_2_2.txt");
		emotion_2_2 = sceneManagerScript.readEmotion("16_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		dialogue_3_1 = sceneManagerScript.readFile("Scene16_3_1.txt");
		emotion_3_1 = sceneManagerScript.readEmotion("16_3_1.txt");
		dialogue_3_1Length = dialogue_3_1.Length;

		dialogue_3_2 = sceneManagerScript.readFile("Scene16_3_2.txt");
		emotion_3_2 = sceneManagerScript.readEmotion("16_3_2.txt");
		dialogue_3_2Length = dialogue_3_2.Length;

		dialogue_4 = sceneManagerScript.readFile("Scene16_4.txt");
		emotion_4 = sceneManagerScript.readEmotion("16_4.txt");
		dialogue_4Length = dialogue_4.Length;

		TomEmo.exit();

		displayDialogue();

		sceneCanvas = sceneCanvas.GetComponent<Canvas>(); 
		sceneCanvas.enabled = true; 
		decision1Canvas = decision1Canvas.GetComponent<Canvas>();
		decision1Canvas.enabled = false;
		decision2Canvas = decision2Canvas.GetComponent<Canvas>();
		decision2Canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			sceneCanvas.enabled = false;

			if (sceneManagerScript.killerID == 4 && sceneManagerScript.userVisited[17]){
				decision2Canvas.enabled = true;
			}
			else{
				decision1Canvas.enabled = true;
			}
		}
		else if (section == 21 && i == dialogue_2_1Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
		else if (section == 22 && i == dialogue_2_2Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(16));
		}
		else if (section == 31 && i == dialogue_3_1Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(19));
		}
		else if (section == 32 && i == dialogue_3_2Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(20));
		}
		else if (section == 4 && i == dialogue_4Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(21));
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			if (!emotion_1[i].Equals("z")){
				emotionCheck(emotion_1[i][0], emotion_1[i][1]);
			}

			if (i==8) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue.text = dialogue_1[i];
			i++;
		}
		else if(section == 21 && i < dialogue_2_1Length){
			if (!emotion_2_1[i].Equals("z")){
				emotionCheck(emotion_2_1[i][0], emotion_2_1[i][1]);
			}

			if (i==0) {
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_2_1[i];
			i++;
		}
		else if(section == 22 && i < dialogue_2_2Length){
			if (!emotion_2_2[i].Equals("z")){
				emotionCheck(emotion_2_2[i][0], emotion_2_2[i][1]);
			}

			if (i==0) {
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_2_2[i];
			i++;
		}
		else if(section == 31 && i < dialogue_3_1Length){
			if (!emotion_3_1[i].Equals("z")){
				emotionCheck(emotion_3_1[i][0], emotion_3_1[i][1]);
			}

			if (i==0) {
				audioManager.playDecisionRes();
			} else if (i==36) {
				audioManager.playClick();
			}
			displayedDialogue.text = dialogue_3_1[i];
			i++;
		}
		else if(section == 32 && i < dialogue_3_2Length){
			if (!emotion_3_2[i].Equals("z")){
				emotionCheck(emotion_3_2[i][0], emotion_3_2[i][1]);
			}

			displayedDialogue.text = dialogue_3_2[i];
			i++;
		}
		else if(section == 4 && i < dialogue_4Length){
			if (!emotion_4[i].Equals("z")){
				emotionCheck(emotion_4[i][0], emotion_4[i][1]);
			}

			displayedDialogue.text = dialogue_4[i];
			i++;
		}
		else{
			i++;
		}
	}

	public void decision1(){
		i = 0;
		if (sceneManagerScript.killerID == 4){
			section = 31;
		}
		else{
			section = 4;
		}
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision2(){
		i = 0;
		section = 22;
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision3(){
		i = 0;
		section = 21;
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision4(){
		i = 0;
		section = 32;
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
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
			JadeEmo.exit();
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
