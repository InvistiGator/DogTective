using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene8Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public Text displayedDialogue_Scene8 =  null;
	private string [] dialogue; 
	private string [] emotion;
	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength;  // defines the length of the dialogue in this scene

	public DougEmotionController DougEmo;
	public JadeEmotionController JadeEmo;
	public DaminaEmotionController DaminaEmo;

	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(8);
		sceneManagerScript.printCurrentKillerID();
		dialogue = sceneManagerScript.readFile("Scene8.txt");
		emotion = sceneManagerScript.readEmotion("8.txt");
		maxDialogueLength = dialogue.Length;

		DaminaEmo.exit();

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			if (!emotion[i].Equals("z")){
				emotionCheck(emotion[i][0], emotion[i][1]);
			}

			displayedDialogue_Scene8.text = dialogue[i];
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
		else if (who.Equals('j')){
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
