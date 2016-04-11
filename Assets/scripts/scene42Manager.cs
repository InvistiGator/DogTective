using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene42Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene42ManagerScript;
	public audio42Script audioManager;
	public Text displayedDialogue_Scene42 =  null;
	private string [] dialogue; 
	private string [] emotion;
	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength;  // defines the length of the dialogue in this scene

	public DougEmotionController DougEmo;
	public JadeEmotionController JadeEmo;
	public NormEmotionController NormEmo;

	public Canvas sceneCanvas;
	public Canvas decision1Canvas;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene42ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio42Script>();
	}
	void Start () {
		scene42ManagerScript.setUserVisited(42);
		scene42ManagerScript.printCurrentKillerID();
		dialogue = scene42ManagerScript.readFile("Scene42.txt");
		emotion = scene42ManagerScript.readEmotion("42.txt");
		maxDialogueLength = dialogue.Length;

		NormEmo.exit();

		displayDialogue();

		sceneCanvas = sceneCanvas.GetComponent<Canvas>(); 
		sceneCanvas.enabled = true; 
		decision1Canvas = decision1Canvas.GetComponent<Canvas>();
		decision1Canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			sceneCanvas.enabled = false;
			decision1Canvas.enabled = true;
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			if (!emotion[i].Equals("z")){
				emotionCheck(emotion[i][0], emotion[i][1]);
			}

			if (i==4) {
				audioManager.playDoorOpen();
			} else if (i==40) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue_Scene42.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

	public void decision1(){
		audioManager.playDecisionRes();
		StartCoroutine(scene42ManagerScript.FadeStuff(45));
	}

	public void decision2(){
		audioManager.playDecisionRes();
		StartCoroutine(scene42ManagerScript.FadeStuff(46));
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
