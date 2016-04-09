using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class whodunnitManager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public Text displayedDialogue =  null;

	private int section = 1;

	public Canvas sceneCanvas;
	public Canvas continueCanvas;

	private string culprit;
	private string evidence;

	//private int i = 0; // a counter to iterater thru conversations, and set important convo indexes
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		sceneManagerScript.printCurrentKillerID();


		displayDialogue();

		sceneCanvas = sceneCanvas.GetComponent<Canvas>(); 
		sceneCanvas.enabled = true;

		continueCanvas = continueCanvas.GetComponent<Canvas>(); 
		continueCanvas.enabled = false;

		sceneManagerScript.characterName.text = "";
		//sceneManagerScript.setEvidenceCollected("pipe", 21);
	}
	
	// Update is called once per frame
	void Update () {
		if (sceneManagerScript.charactersCanvas.enabled == true){
			if (!sceneManagerScript.characterName.text.Equals("")){
				culprit = sceneManagerScript.characterName.text;
				continueCanvas.enabled = true;
			}
			else{
				continueCanvas.enabled = false;
			}
		}
		else if (sceneManagerScript.evidenceCanvas.enabled == true){
			if (!sceneManagerScript.evidenceInfo.text.Equals("")){
				evidence = sceneManagerScript.evidenceInfo.text;
				continueCanvas.enabled = true;
			}
			else{
				continueCanvas.enabled = false;
			}
		}
	}

	
	public void displayDialogue(){
		if(section == 1){
			displayedDialogue.text = "Jade: “So, Doug, it’s starting to feel like this investigation is wrapping up.”";
			section = 2;
		}
		else if (section == 2){
			displayedDialogue.text = "Jade: “Who do you think the culprit is and what is a piece of evidence we could use to prove that?”";
			section = 3;
		}
		else if (section == 3){
			sceneCanvas.enabled = false;
			sceneManagerScript.charactersCanvas.enabled = true;
			sceneManagerScript.characterBack.enabled = false;
		}
		else if (section == 4){
			sceneCanvas.enabled = false;
			sceneManagerScript.evidenceCanvas.enabled = true;
			sceneManagerScript.evidenceBack.enabled = false;
		}
		else if (section == 5){
			displayedDialogue.text = "Jade: “Are you sure? I don’t believe that quite makes sense… Remember, anyone could be the culprit.”";
			section = 2;
		}
		else if (section == 6){
			displayedDialogue.text = "Jade: “I agree. That seems pretty likely.”";
			section = -1;
		}
		else if (section == 7){
			displayedDialogue.text = "Doug: No… That can’t be…";
			section = -1;
		}
		else if (section == 8){
			displayedDialogue.text = "Doug: …";
			section = -1;
		}
		else if (section == -1){
			if (sceneManagerScript.killerID == 3 || sceneManagerScript.killerID == 4){
				StartCoroutine(sceneManagerScript.FadeStuff(9));
			}
			else if (sceneManagerScript.killerID == 5 || sceneManagerScript.killerID == 6){
				StartCoroutine(sceneManagerScript.FadeStuff(30));
			}
			else if (sceneManagerScript.killerID == 0){
				StartCoroutine(sceneManagerScript.FadeStuff(44));
			}
			else if (sceneManagerScript.killerID == 1){
				StartCoroutine(sceneManagerScript.FadeStuff(43));
			}
			else if (sceneManagerScript.killerID == 2){
				StartCoroutine(sceneManagerScript.FadeStuff(42));
			}

		}
	}

	public void continueClicked(){
		if (section == 3){
			section = 4;
			culprit = sceneManagerScript.characterName.text;
			continueCanvas.enabled = false;
			sceneManagerScript.characterBack.enabled = true;
			sceneManagerScript.charactersCanvas.enabled = false;
			sceneCanvas.enabled = true;
			displayDialogue();
		}
		else if (section == 4){
			evidence = sceneManagerScript.evidenceInfo.text;
			section = correctCheck();
			continueCanvas.enabled = false;
			sceneManagerScript.evidenceBack.enabled = true;
			sceneManagerScript.evidenceCanvas.enabled = false;
			sceneCanvas.enabled = true;
			displayDialogue();
		}
	}

	public int correctCheck(){
		if (sceneManagerScript.killerID == 0){
			if (culprit.Equals("Doug “Ace” Ventose \nThe Baffling Detective") && (evidence.Equals("Light Brown Fur\nThere was some light brown fur at the scene of the crime. Kinda looks like some of the patches of my fur.") || evidence.Equals("Pipe\nIt seems like Norm had a pipe. If only I would have known... He and I could have had pipe parties where we sit around looking like cool detectives!") || evidence.Equals("Norm's Classes with Doug\nI barely remember him, but I know Norm and I took some classes together. Poor guy could never catch a break."))){
				return 8;
			}
		}
		else if (sceneManagerScript.killerID == 1){
			if (culprit.Equals("Jade Heimdall \nThe Sly Sidekick") && (evidence.Equals("White Fur\nFound some pretty average white fur at the scene of the crime. It looks really familar... Probably because so many cats and dogs have some white fur.") || evidence.Equals("School Club\nNorm was in our high school's Science Club with Jade. He worked so hard, but I guess science wasn't his calling either.") || evidence.Equals("No School Records\nNorm's school records were completely deleted. Someone with 1337 h4ck1ng skills must be up to something here..."))){
				return 8;
			}
		}
		else if (sceneManagerScript.killerID == 2){
			if (culprit.Equals("Norm Previse \nThe Hapless Deceased") && (evidence.Equals("Candy Wrapper\nFound at the scene of the crime. Norm might have been addicted to chocolate.") || evidence.Equals("No Body\nWhen I first went to the scene of the crime, Norm's body wasn't there! Where could it have gone?") || evidence.Equals("Newspaper Clipping\nHey, look! That's me! I remember catching that cat burgler red-handed! I only caught him because he bumped into me on the street while running from the cops, but that still counts!"))){
				return 7;
			}
		}
		else if (sceneManagerScript.killerID == 3){
			if (culprit.Equals("Damina Punctum \nThe Unassuming Chief") && (evidence.Equals("Long White Fur\nBeautiful, long, white hairs, clearly from a great creature in its prime. Found at the crime scene.") || evidence.Equals("The Body Returned\nNorm's body magically appeared at the scene of the crime the second time I was there. How did it disappear and reappear like that?!") || evidence.Equals("Norm's Secret Passage\nWow, Norm has a secret passage connected to his house. It would be so awesome to have that in your house. I wonder if Norm's house is for sale..."))){
				return 7;
			}
		}
		else if (sceneManagerScript.killerID == 4){
			if (culprit.Equals("Tom “Sweet Tooth” Confetto \nThe Amiable Mobster") && (evidence.Equals("Candy Wrapper\nFound at the scene of the crime. Norm might have been addicted to chocolate.") || evidence.Equals("Short White Fur\nThere was some of this fur at the scene of the crime. It is short, white, and thin.") || evidence.Equals("Norm's Secret Passage\nWow, Norm has a secret passage connected to his house. It would be so awesome to have that in your house. I wonder if Norm's house is for sale..."))){
				return 6;
			}
		}
		else if (sceneManagerScript.killerID == 5){
			if (culprit.Equals("Goldie Weal \nThe Arrogant Executive") && (evidence.Equals("Money\nWho would leave a bunch of money at the scene of a crime. Is this Norm's or someone else's?") || evidence.Equals("Norm's Classes with Goldie\nNorm took some classes with Goldie, so they must have known each other. Were they friends?"))){
				return 6;
			}
		}
		else if (sceneManagerScript.killerID == 6){
			if (culprit.Equals("Morgan Evetta \nThe Shrewd Lawyer") && (evidence.Equals("Papers from Work\nLooks like Norm was bringing his work home with him. ...this stuff isn't nearly as cool as my job is!") || evidence.Equals("Pink Slip\nWas Norm going to be fired? Well, I guess he doesn't have to worry about his job anymore...") || evidence.Equals("Tie\nA tie. It looks like Tom's, but Morgan gave it to me. Do I trust this as a piece of evidence?"))){
				return 6;
			}
		}
		
		return 5;
	}

}
