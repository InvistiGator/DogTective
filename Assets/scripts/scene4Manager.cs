using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene4Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public Text displayedDialogue_Scene4 =  null;
	private string [] dialogue; 
	private string [] emotion;

	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength;  // defines the length of the dialogue in this scene

	public DougEmotionController DougEmo;
	public TomEmotionController TomEmo;

	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(4);
		sceneManagerScript.printCurrentKillerID();
		dialogue = sceneManagerScript.readFile("Scene4.txt");
		emotion = sceneManagerScript.readEmotion("4.txt");
		maxDialogueLength = dialogue.Length;

		TomEmo.exit();

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			if (sceneManagerScript.userVisited[3] && !sceneManagerScript.userVisited[5]){
			    StartCoroutine(sceneManagerScript.FadeStuff(5));
			}
			else if (sceneManagerScript.userVisited[3] && sceneManagerScript.userVisited[5]){
				StartCoroutine(sceneManagerScript.FadeStuff(6));
			}
			else{
				StartCoroutine(sceneManagerScript.FadeStuff(3));
			}
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			if (!emotion[i].Equals("z")){
				emotionCheck(emotion[i][0], emotion[i][1]);
			}

			displayedDialogue_Scene4.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

	public void emotionCheck(char who, char what){
		if (who.Equals('t')){
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
