using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene43Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene43ManagerScript;
	public audio43Script audioManager;
	public Text displayedDialogue_Scene43 =  null;
	private string [] dialogue; 
	private string [] emotion;
	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength;  // defines the length of the dialogue in this scene

	public DougEmotionController DougEmo;
	public JadeEmotionController JadeEmo;

	public Canvas sceneCanvas;
	public Canvas decision1Canvas;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene43ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio43Script>();
	}
	void Start () {
		scene43ManagerScript.setUserVisited(43);
		scene43ManagerScript.printCurrentKillerID();
		dialogue = scene43ManagerScript.readFile("Scene43.txt");
		emotion = scene43ManagerScript.readEmotion("43.txt");
		maxDialogueLength = dialogue.Length;

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

			if (i==33) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue_Scene43.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

	public void decision1(){
		audioManager.playDecisionRes();
		StartCoroutine(scene43ManagerScript.FadeStuff(48));
	}

	public void decision2(){
		audioManager.playDecisionRes();
		StartCoroutine(scene43ManagerScript.FadeStuff(47));
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
