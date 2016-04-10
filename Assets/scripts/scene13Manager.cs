using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene13Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public Text displayedDialogue =  null;

	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;

	private string [] emotion_1;
	private string [] emotion_2_1;
	private string [] emotion_2_2;

	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;

	private int section = 1;

	public DougEmotionController DougEmo;
	public JadeEmotionController JadeEmo;
	public MorganEmotionController MorganEmo;

	private int i= 0; // a counter to iterate thru conversations, and set important convo indexes
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
		sceneManagerScript.setUserVisited(13);
		sceneManagerScript.printCurrentKillerID();

		dialogue_1 = sceneManagerScript.readFile("Scene13_1.txt");
		emotion_1 = sceneManagerScript.readEmotion("13_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = sceneManagerScript.readFile("Scene13_2_1.txt");
		emotion_2_1 = sceneManagerScript.readEmotion("13_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = sceneManagerScript.readFile("Scene13_2_2.txt");
		emotion_2_2 = sceneManagerScript.readEmotion("13_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		MorganEmo.exit();

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		//if counter reached the max dialogue length, move onto next scene
		if(section == 1 && i == dialogue_1Length+1){
			sceneManagerScript.setEvidenceCollected("Knocking", 22);
			if (sceneManagerScript.userVisited[12]){
				section = 22;
				i = 0;
				displayDialogue();
			}
			else{
				section = 21;
				i = 0;
				displayDialogue();
			}
		}
		else if (section == 21 && i == dialogue_2_1Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
		else if (section == 22 && i == dialogue_2_2Length+1){
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
		else if (section == 21 && i < dialogue_2_1Length){
			if (!emotion_2_1[i].Equals("z")){
				emotionCheck(emotion_2_1[i][0], emotion_2_1[i][1]);
			}

			displayedDialogue.text = dialogue_2_1[i];
			i++;
		}
		else if (section == 22 && i < dialogue_2_2Length){
			if (!emotion_2_2[i].Equals("z")){
				emotionCheck(emotion_2_2[i][0], emotion_2_2[i][1]);
			}

			displayedDialogue.text = dialogue_2_2[i];
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
