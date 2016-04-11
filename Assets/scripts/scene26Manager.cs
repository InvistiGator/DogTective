using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene26Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;

	private string [] emotion_1;

	private int dialogue_1Length;

	private int section = 1;

	public DougEmotionController DougEmo;
	public JadeEmotionController JadeEmo;
	public DaminaEmotionController DaminaEmo;

	private int i = 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(26);
		sceneManagerScript.printCurrentKillerID();

		if (!sceneManagerScript.lookForEvidence("tie") && sceneManagerScript.userVisited[25]){
			dialogue_1 = sceneManagerScript.readFile("Scene26_1.txt");
			emotion_1 = sceneManagerScript.readEmotion("26_1.txt");
			dialogue_1Length = dialogue_1.Length;
		}
		else{
			dialogue_1 = sceneManagerScript.readFile("Scene26_2.txt");
			emotion_1 = sceneManagerScript.readEmotion("26_2.txt");
			dialogue_1Length = dialogue_1.Length;
		}

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			if (!emotion_1[i].Equals("z")){
				emotionCheck(emotion_1[i][0], emotion_1[i][1]);
			}

			displayedDialogue.text = dialogue_1[i];
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
