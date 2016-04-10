using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene12Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio12Script audioManager;
	public Text displayedDialogue_Scene12 =  null;
	private string [] dialogue; 
	private string [] emotion;
	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength;  // defines the length of the dialogue in this scene
	// Use this for initialization

	public DougEmotionController DougEmo;
	public JadeEmotionController JadeEmo;

	public SpriteRenderer secretPassage;
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio12Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(12);
		sceneManagerScript.printCurrentKillerID();
		dialogue = sceneManagerScript.readFile("Scene12.txt");
		emotion = sceneManagerScript.readEmotion("12.txt");
		maxDialogueLength = dialogue.Length;

		secretPassage = secretPassage.GetComponent<SpriteRenderer>();

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			sceneManagerScript.setEvidenceCollected("TomsSecretPassage", 24);
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			if (!emotion[i].Equals("z")){
				emotionCheck(emotion[i][0], emotion[i][1]);
			}

			if (i==36){
				secretPassage.enabled = false;
			}

			if (i==33) {
				audioManager.playFootsteps();
			}
			displayedDialogue_Scene12.text = dialogue[i];
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
