using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene2Manager : MonoBehaviour {
//private scene2Manager: SceneHandler;
	public GameObject SceneHandlerObj;
	public SceneHandler scene2ManagerScript;

	public GameObject bodyObject;
	public bool [] stageInThisScene;
	public int walkedUpToCount = 0;
	//script for script GUI stuff
	public bool displayGUI;
	public Canvas scene2CanvasObj;
	public Text displayeddialogue_Scene2;

	public Canvas bloodCanvasObj;
	public Button touchBloodButt;
	public Button noTouchBloodButt;

	public int maxEvidenceNum;
	//diff versions of the dialogues
	//
	private int maxdialogueInitLength = 7;  // defines the length of the dialogueInit in this scene
	private string [] dialogueInit; 
	// versions of mid convo
	
	private int maxMidDialogueLength;
	private string [] dialogue2_1;
	//private string [] dialogue2_2;

	//versions of blood-mid convo
	private int maxInitBloodLength;
	private string [] dialogue3_1;

	private int maxBloodDialogueLength;
	private string [] dialogue3_2;

	private int maxEvidenceDialogue;
	private string [] dialogue4_1;
	//last convo
	private int maxEndDialogueLength;
	private string [] dialogueEnd;


	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	// Use this for initialization
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene2ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();

		//bodyObject = GameObject.FindGameObject("Body").gameObject.GetComponent<GameObject> as GameObject;

	}
	void Start () {
		displayGUI = true;
		scene2ManagerScript.setUserVisited(2);
		scene2ManagerScript.printCurrentKillerID();

		loadEvidencesBaseOnKiller();

		stageInThisScene = new bool[6];			//there are 6 different stages that can determine how dialogues changes
		for(int i=0; i<stageInThisScene.Length; i++){
			stageInThisScene[i] = false;
		}
		scene2CanvasObj = scene2CanvasObj.GetComponent<Canvas>();
		//touchBloodButt = touchBloodButt.GetComponent<Button>();
		//noTouchBloodButt = noTouchBloodButt.GetComponent<Button();
		bloodCanvasObj = bloodCanvasObj.GetComponent<Canvas>();

		bloodCanvasObj.enabled = false;
		touchBloodButt.enabled = false;
		noTouchBloodButt.enabled = false;

		//displayeddialogue_Scene2 = displayeddialogue_Scene2.GetComponent<Text>();
		setUpInitScript();
		setUpMidScript();
		setUpBloodInitScript();
		setUpEndScript();
	}
	
	// Update is called once per frame
	void Update () {
		displayGUIorNah();

		if (bloodCanvasObj.enabled == true){
			Time.timeScale = 0;
		}

		//if counter reached the max dialogueInit length, move onto next scene
		
		if(stageInThisScene[5] && lookForEvidence("blood")){
			SceneManager.LoadScene(3);
			Debug.Log("loading scene3 bc blood touched");
		}
		if(stageInThisScene[5]){
			SceneManager.LoadScene(4);
			Debug.Log("loading scene4 bc blood not Touched");
		}
		
	}

	public void displayGUIorNah(){
		if(displayGUI){
			scene2CanvasObj.enabled = true;
			Time.timeScale = 0;
			//displayeddialogue_Scene2.enabled = true;
		}
		else{
			scene2CanvasObj.enabled = false;
			Time.timeScale = 1;
			//displayeddialogue_Scene2.enabled = false;
		}
	}
	public void loadEvidencesBaseOnKiller(){
		showBodyOrNah();
		//load basic evidences (red pen and candy wrapper)
		if(scene2ManagerScript.killerID == 0){//if Doug is killer
			//light brown hair
			maxEvidenceNum = 4;//Blood = inclusive, Body is exclusive in the calculation of maxEvidenceNum per scene
		}
		else if(scene2ManagerScript.killerID == 1){//if Jade is killer
			//enable money
			maxEvidenceNum = 4;
		}
		else if(scene2ManagerScript.killerID == 2){//if Norm is killer
			//no additional other than the body
			maxEvidenceNum = 3;
		}
		else if(scene2ManagerScript.killerID == 3){//if Damina is killer
			//no body and long white fur
			maxEvidenceNum = 4;
		}
		else if(scene2ManagerScript.killerID == 4){//if Tom is killer
			//enable white fur
			maxEvidenceNum = 4;
		}
		else if(scene2ManagerScript.killerID == 5){//if Goldie is killer
			//enable money
			maxEvidenceNum = 4;
		}
		else if(scene2ManagerScript.killerID == 6){//if Morgan is killer
			//enable papers from work
			maxEvidenceNum = 4;
		}
	}
	public void showBodyOrNah(){
		if(scene2ManagerScript.killerID == 2 || scene2ManagerScript.killerID == 3 ){
			bodyObject.SetActive(false);
		}
		else{
			bodyObject.SetActive(true);
		}
	}

	public bool lookForEvidence(string evidence_){
		for(int i=0; i< scene2ManagerScript.CollectedEvidenceString.Length; i++){
			if(scene2ManagerScript.CollectedEvidenceString[i] == evidence_){
				return true;
			}
		}

		return false;
	}
		public void displayDialogue(){
		if(!stageInThisScene[0]){
			if(i<maxdialogueInitLength){
				//i++;
				displaydialogueInit();
			}
			else{
				//reset temp stuff//
				i = 0; 
				//displayGUI=false;
				//displayeddialogue_Scene2.enabled = false;
				displayeddialogue_Scene2.text = "*Sniff*  Sniff*"; 
				stageInThisScene[0] = true;
				Debug.Log("I'm inside of the !stageInThisScene[0]'s else statement");
			}
		}

		else if(!stageInThisScene[1]){
			if(i<maxMidDialogueLength){
				//i++;
				displaydialogueMid();
			}
			else{
				//reset temp stuff//
				i = 0; 
				displayGUI=false;
				//displayeddialogue_Scene2.enabled = false;
				stageInThisScene[1] = true;
				Debug.Log("I'm inside of the !stageInThisScene[1]'s else statement");
			}
		}
		else if(!stageInThisScene[2]){
			if(i<maxInitBloodLength){
				//i++;
				Debug.Log("i counter inside stage[2]: " + i);
				displayInitBlood();
			}
			else{
				//reset temp stuff//
				i = 0; 
				displayGUI=false;

				bloodCanvasObj.enabled = true;
				touchBloodButt.enabled = true;
				noTouchBloodButt.enabled = true;

				//displayeddialogue_Scene2.enabled = false;
				stageInThisScene[2] = true;
				decideToTouchBlood();
				Debug.Log("I'm inside of the !stageInThisScene[2]'s else statement");
			}
		}
		else if(!stageInThisScene[3]){

			bloodCanvasObj.enabled = false;
			touchBloodButt.enabled = false;
			noTouchBloodButt.enabled = false;
			
			if(i<maxBloodDialogueLength){
				//i++;
				displaydialogueBlood();
			}
			else{
				//reset temp stuff//
				bloodCanvasObj.enabled = false;
				touchBloodButt.enabled = false;
				noTouchBloodButt.enabled = false;
				i = 0; 
				displayGUI=false;
				//displayeddialogue_Scene2.enabled = false;
				stageInThisScene[3] = true;
				Debug.Log("I'm inside of the !stageInThisScene[3]'s else statement");
			}
		}
		else if(!stageInThisScene[4]){
			displayGUI = true;
			setUpEvidenceScript();
			//inside of you've collected all the evidence
			if(i<maxEvidenceDialogue){
				//i++;
				displayEvidenceDialogue();
			}
			else{
				//reset temp stuff//
				i = 0; 
				//displayGUI=false;
				//displayeddialogue_Scene2.enabled = false;
				stageInThisScene[4] = true;
				Debug.Log("I'm inside of the !stageInThisScene[4]'s else statement");
			}
		}

		else if(!stageInThisScene[5]){
			if(i<maxEndDialogueLength){
				//i++;
				displaydialogueEnd();
			}
			else{
				//reset temp stuff//
				i = 0; 
				displayGUI=false;
				//displayeddialogue_Scene2.enabled = false;
				stageInThisScene[5] = true;
				Debug.Log("I'm inside of the !stageInThisScene[5]'s else statement");
			}
		}
		
	}

	public bool allEvidenceCollectd(){
		if(walkedUpToCount == maxEvidenceNum){
			return true;
		}
		return false;
	}

	///===============Set Up different variations of GUI ========================///

	public void setUpInitScript(){
		dialogueInit = new string[maxdialogueInitLength];
		dialogueInit[0] = "Doug: (Ah, the first murder scene I’ve actually been invited to investigate. It feels good to rise the ranks of the ace detective world.)";
		dialogueInit[1] = "Chief Punctum: Look who finally made it. Good to have you here, Ace. As is plain to see, things… got pretty hairy." ;
		dialogueInit[2] = "Doug: Is now really the time for jokes, chief? ";
		dialogueInit[3] = "Chief Punctum: Aw, come now. Don’t be a grumpy greyhound. It’s always best to catch villains while in high spirits.";
		dialogueInit[4] = "(Doug: She really is as far from being a noir detective as you can get. Sometimes I wish I had a more dramatic role model...)";
		dialogueInit[5] = "Doug: Whatever you say, chief.";
		dialogueInit[6] = "Doug: Anyway, thanks for letting me be a part of this investigation. Time to start investigating!";

		displayeddialogue_Scene2.text = dialogueInit[i];
		i++;
	}

	public void setUpMidScript(){
		if(!(scene2ManagerScript.killerID == 2 || scene2ManagerScript.killerID == 3) ){
			maxMidDialogueLength = 5;
			dialogue2_1 = new string[maxMidDialogueLength];
			dialogue2_1[0] = "Doug: Ah, the classic murder scene. A room, a body, and wow that’s a LOT of blood.";
			dialogue2_1[1] = "Chief Punctum: Right on all counts there, Ace. You could practically swim in that pool of blood.";
			dialogue2_1[2] = "Chief Punctum: Don’t get squeamish on me now, though. You’ve got a lot of sleuthing to do today.";
			dialogue2_1[3] = "Chief Punctum: Plus, anything and everything in this room could be evidence, so don’t just focus on one thing.";
			dialogue2_1[4] = "Doug: Of course, chief. If there are any clues, I’ll sniff them out.";

		}
		else{
			maxMidDialogueLength = 9;
			dialogue2_1 = new string[maxMidDialogueLength];
			dialogue2_1[0] = "Doug: Um… Chief?";
			dialogue2_1[1] = "Chief Punctum: What? Is something the matter already, Ace?";
			dialogue2_1[2] = "Doug: So, I know I’m pretty new to the whole detective thing, but isn’t there normally… I don’t know… a dead body at the scene of a murder?";
			dialogue2_1[3] = "Chief Punctum: Good thing to notice there, Ace. There’s no body, but we’ve got a pool of blood big enough to swim in there. Nobody could lose that much blood and live, right";
			dialogue2_1[4] = "Doug: Yeah… but, how do we know it wasn’t somebody else who died? Or maybe his death was faked?";
			dialogue2_1[5] = "Doug: I don’t know; things seem like they’ll be so much more difficult without a dead body there to get evidence from.";
			dialogue2_1[6] = "Chief Punctum: Ah, it’s good to see you thinking like a detective. *sniff* You’re growing up so fast…";
			dialogue2_1[7] = "Chief Punctum: Just rely on your detective’s instinct, and I’m sure you’ll be fine.";
			dialogue2_1[8] = "Doug: Of course, chief. If there are any clues, I’ll sniff them out immediately.";
		}	
	}
	public void setUpBloodInitScript(){
		maxInitBloodLength = 9;
		dialogue3_1 = new string[maxInitBloodLength];
		dialogue3_1[0] = "Doug: (Hm… it really is strange how much blood there is everywhere…)";
		dialogue3_1[1] = "Doug: (I know we’ve got a lot of the stuff flowing through our veins, but normally you don’t see this much of it at once; even at the scene of a murder.)";
		dialogue3_1[2] = "Doug: (This seems like a really important piece of evidence… so is there anything I can do to investigate further?)";
		dialogue3_1[3] = "Doug: (Oh! I know!)";
		dialogue3_1[4] = "Doug: (In some of those classic murder mysteries, the detective will take a little blood and rub it in between their fingers.)";
		dialogue3_1[5] = "Doug: (Then, through sheer ingenuity, they will learn something about how the victim died.)";
		dialogue3_1[6] = "Doug: (Hm… I don’t know if I should do that, though.)";
		dialogue3_1[7] = "Doug: (The police have a bunch of new ways of analyzing blood these days, so the chief might get mad at me for ‘contaminating the evidence’ and whatnot.)";
		dialogue3_1[8] = "(Doug: It would be really cool if I could actually learn something from touching the blood like that, though…)";

	}
	public void setUpEvidenceScript(){
		if(lookForEvidence("blood")){
			maxEvidenceDialogue = 20;
			dialogue4_1 = new string [maxEvidenceDialogue];
			dialogue4_1[0] = "Doug: (I think that’s just about every piece of evidence there is to find here.)"; 
			dialogue4_1[1] = "Doug: (The hairs and chocolate I found make for good starting points of an investigation.)"; 
			dialogue4_1[2] = "Doug: (I should talk to the chief so I can start thinking about possible suspects.)"; 
			dialogue4_1[3] = "Doug: Hey chief, I think I’ve found almost everything that I need to start analyzing what happened here."; 
			dialogue4_1[4] = "Chief Punctum: Yup, you sure left no bone unturned here, didn’t you?"; 
			dialogue4_1[5] = "Doug: So, the next thing I’d imagine I have to start handling are suspects and people who know what might have happened here."; 
			dialogue4_1[6] = "Doug: Chief Punctum: You’re on the right track there, Ace. Is there anything I can do to help?"; 
			dialogue4_1[7] = "Doug: Well, since that blood actually turned out to be ink, I was trying to think about where that much ink could have come from."; 
			dialogue4_1[8] = "Doug: Could you tell me where it was that Norm worked?"; 
			dialogue4_1[9] = "Chief Punctum: Ah yes, the deceased’s place of work."; 
			dialogue4_1[10] = "Chief Punctum: He worked for KT Corporation, that ridiculous company that owns so much of this city."; 
			dialogue4_1[11] = "Chief Punctum: Specifically, he worked for their law division, Weal Law Associates. Apparently, they hired the kitten straight out of high school."; 
			dialogue4_1[12] = "Doug: Well, for something as big as a murder, I think I better go straight to the top and  see if the big boss animal knows anything."; 
			dialogue4_1[13] = "Chief Punctum: Um… You sure about that, Ace? You could just talk to whoever knew him best"; 
			dialogue4_1[14] = "Doug: Nope. This is a great opportunity to go right to the top and see if anything shady was going down at the company."; 
			dialogue4_1[15] = "Chief Punctum: Ha ha, you’re really thinking big there, Ace. Just make sure you don’t get in over your head, and always keep your wits about you."; 
			dialogue4_1[16] = "Chief Punctum: You can’t let these people push you around, but you don’t want to make too many enemies either."; 
			dialogue4_1[17] = "Doug: Thanks for the advice, chief. Got anything else I should know?"; 
			dialogue4_1[18] = "Chief Punctum: Don’t forget about that chocolate you found here. You must know how bad a drug chocolate is and how that vile Confetto runs the sweets business with an iron paw."; 
			dialogue4_1[19] = "Chief Punctum: “So you may want to investigate him too, but be very careful. He isn’t as sweet as he might appear."; 
		}
		else{
			maxEvidenceDialogue = 18;
			dialogue4_1 = new string [maxEvidenceDialogue];
			dialogue4_1[0] = "Doug: (I think that’s just about every piece of evidence there is to find here.)"; 
			dialogue4_1[1] = "Doug: (The hairs and chocolate I found make for good starting points of an investigation.)"; 
			dialogue4_1[2] = "Doug: (I should talk to the chief so I can start thinking about possible suspects.)"; 
			dialogue4_1[3] = "Doug: Hey chief, I think I’ve found almost everything that I need to start analyzing what happened here."; 
			dialogue4_1[4] = "Chief Punctum: Yup, you sure left no bone unturned here, didn’t you?"; 
			dialogue4_1[5] = "Doug: So, the next thing I’d imagine I have to start handling are suspects and people who know what might have happened here."; 
			dialogue4_1[6] = "Doug: Chief Punctum: You’re on the right track there, Ace. Is there anything I can do to help?"; 
			dialogue4_1[7] = "Doug: Well, since I found that chocolate, I was thinking that I should find the dealer who sold it to him. Only one person in this town comes to mind for that…"; 
			dialogue4_1[8] = "Chief Punctum: Tom ‘Sweet Tooth’ Confetto. That *meow* dog has eluded me for so many years."; 
			dialogue4_1[9] = "Chief Punctum: Be very careful investigating him, Ace. He may seem like he’s a nice old dog at first, but he can turn on you at any moment."; 
			dialogue4_1[10] = "Chief Punctum: And I don’t have to tell you the *meow* that drugs can do to your body, so our friend Norm might not have been quite himself when he died."; 
			dialogue4_1[11] = "Doug: Don’t worry. If he was involved in any way with all this I’ll wring it out of him."; 
			dialogue4_1[12] = "Chief Punctum: Wow, just gonna waltz right up to the biggest chocolate dealer in town, huh? You got guts, Ace."; 
			dialogue4_1[13] = "Chief Punctum: You can usually find him hanging out at his bar, The Sultry Saloon, relaxing with his confectionary confidantes."; 
			dialogue4_1[14] = "Doug: Thanks for the info, chief. Got anything else I should know?"; 
			dialogue4_1[15] = "Chief Punctum: Norm worked for KT Corporation, those fat cats and dogs who own half of this city."; 
			dialogue4_1[16] = "Chief Punctum: More specifically, he was hired by their law division, Weal Law Associates."; 
			dialogue4_1[17] = "Chief Punctum: His coworkers and bosses there might know something about how he died, so you should sniff them out at some point."; 
		}
	}
	public void setUpEndScript(){
		maxEndDialogueLength = 12;
		dialogueEnd = new string[maxEndDialogueLength];
		dialogueEnd[0] = "Doug: Alrighty. I already have a few people I can investigate…";
		dialogueEnd[1] = "Doug: Time to go find a murderer…";
		dialogueEnd[2] = "Doug: I am SO cool!";
		dialogueEnd[3] = "Doug: *woof* That buzzing again! Oh, it’s just Jade.";
		dialogueEnd[4] = "Doug: Hey, Jade. What’s up?";
		dialogueEnd[5] = "Jade: I am sorry for not arriving yet. I’ll try to catch up with you soon.";
		dialogueEnd[6] = "Jade: I did manage to quickly gather some information on Norm and several people who were close to him.";
		dialogueEnd[7] = "Jade: I’ve sent all the info to your phone so you can check it whenever you need.";
		dialogueEnd[8] = "Doug: I’m still not used to all of this smartphone stuff, but I’ll definitely take a look at what you’ve sent me and jot down some notes on my trusty notepad.";
		dialogueEnd[9] = "Jade: *sigh* I’ll bring you over to the 21st century someday, Doug.";
		dialogueEnd[10] = "Doug: Who needs all of that technology? Like the great Holmes and Watson, I’m sure we can solve any case if we put our minds together.";
		dialogueEnd[11] = "Doug: Bye Jade.";

	}

	public void displaydialogueInit(){
		if(i<maxdialogueInitLength){
			displayeddialogue_Scene2.text = dialogueInit[i];
			i++;
		}
	}
	public void displaydialogueMid(){
		if(i<maxMidDialogueLength){
			displayeddialogue_Scene2.text = dialogue2_1[i];
			i++;
		}
	}
	public void displayInitBlood(){
		if(i<maxInitBloodLength){
			Debug.Log("i counter right before disply init blood: " + i);
			displayeddialogue_Scene2.text = dialogue3_1[i];
			i++;
		}
	}
	public void displayEvidenceDialogue(){
		if(i<maxEvidenceDialogue){
			displayeddialogue_Scene2.text = dialogue4_1[i];
			i++;
		}
	}
	public void displaydialogueEnd(){
		if(i<maxEndDialogueLength){
			displayeddialogue_Scene2.text = dialogueEnd[i];
			i++;
		}
	}

/*
	public void bloodGUI(){
		displayGUI=true;
		if(i<maxInitBloodLength){
			displayInitBlood();
		}
		//pop up decision GUI
		decideToTouchBlood();
		//turn off GUI when stuff is done
		displayGUI=false;
	}
*/
	public void decideToTouchBlood(){
		//enable Blood GUI stuff;
		bloodCanvasObj.enabled = true;
		touchBloodButt.enabled = true;
		noTouchBloodButt.enabled = true;
	}
	public void touchBlood(){
		//the button associated with touching blood
		//set up everything
		//person decided to touch blood. Add this to their evidence inventory. 
		scene2ManagerScript.setEvidenceCollected("blood",2);
		//[Audio: Blood's event sound]
	/*			
	//Randomization: If Norm or Damina is the culprit:
	Doug:  But with no blood and no body… was there even a murder at all?

 */
		if(scene2ManagerScript.killerID==2||scene2ManagerScript.killerID==3){
			maxBloodDialogueLength = 26;
			setUpTouchBlood();
			dialogue3_2[25] = "Doug: (But with no blood and no body… was there even a murder at all?)";
		}
		else{
			maxBloodDialogueLength = 25;
			setUpTouchBlood();
		}	
	
		int i=0;//reset i to 0 just incase, counter has some random memory stored in it. 
		if(i<maxBloodDialogueLength){
			displayGUI=true;
			displaydialogueBlood();
		}
	}

	public void setUpTouchBlood(){
		dialogue3_2 = new string[maxBloodDialogueLength];
		dialogue3_2[0] = "Doug: Hm…" ;
		dialogue3_2[1] = "*You rub the blood between your fingers, faster now.*";
		dialogue3_2[2] = "Doug: Hm……";
		dialogue3_2[3] = "Doug: (Isn’t blood supposed to be sticky? This feels pretty weird.)";
		dialogue3_2[4] = "Doug: (Anyway, that’s about all I’m getting from this. Wow, old school detectives must have been so good at all this blood-touching.)";
		dialogue3_2[5] = "Doug: (I should wipe it off of my fingers and find out what not-sticky blood may mean.)";
		dialogue3_2[6] = "*You try to wipe the blood off of your fingers.*";
		dialogue3_2[7] = "*Doug: Huh? It isn’t coming off…";
		dialogue3_2[8] = "*You try wiping it off harder and your hands are now completely covered in blood.*";
		dialogue3_2[9] = "*Doug: Oh no! This was a bad idea! Bad idea!";
		dialogue3_2[10] = "Chief Punctum: Looks like I’ve… caught you red-handed.";
		dialogue3_2[11] = "Doug: No! Chief, it’s not what it looks like! I’m so sor-- Wait a second, here…";
		dialogue3_2[12] = "Chief Punctum: You got an explanation for this, Ventose?";
		dialogue3_2[13] = "Doug: This blood isn’t sticky, doesn’t wipe off, and is completely staining my fingers…";
		dialogue3_2[14] = "Doug: Chief! I knew it!";
		dialogue3_2[15] = "Chief Punctum: This better be good…";
		dialogue3_2[16] = "Doug: I definitely thought that the blood looked a little weird, not to mention how much of it there was.";
		dialogue3_2[17] = "Doug: “So… I was thinking that it wasn’t blood at all, so I touched it and my suspicions were confirmed!";
		dialogue3_2[18] = "Chief Punctum: Then what is it?";
		dialogue3_2[19] = "Doug: It’s red ink, chief! It isn’t actually blood.";
		dialogue3_2[20] = "Chief Punctum: Wow, nice catch there, Ace. They say that us cats have good eyesight, but my old age might be getting to me. Great job figuring that out.";
		dialogue3_2[21] = "Doug: “Of course! You can count on me!";
		dialogue3_2[22] = "Doug: (Whew, she bought it…)";
		dialogue3_2[23] = "Doug:  (I really didn’t know what I was doing, but I accidentally discovered a major clue!)";
		dialogue3_2[24] = "Doug:  Looks like my curiosity paid off today.";
	}
	public void notToTouchBlood(){
		//button associated with NOT touching blood
		maxBloodDialogueLength = 3;
		dialogue3_2 = new string[maxBloodDialogueLength];
		dialogue3_2[0] = "Doug: (Yeah. It’s better not to touch it.)";
		dialogue3_2[1] = "Doug: (I shouldn’t contaminate or alter the crime scene in any way. That’s, like, the first rule of detective work.)";
		dialogue3_2[2] = "Doug: (Still, I should take note of just how much blood there is. It’s probably still related to the case somehow.)";

		int i=0;//reset i to 0 just incase, counter has some random memory stored in it. 
		if(i<maxBloodDialogueLength){
			displayGUI=true;
			displaydialogueBlood();
		}
	}
	public void displaydialogueBlood(){
		if(i<maxBloodDialogueLength){
			displayeddialogue_Scene2.text = dialogue3_2[i];
			i++;
		}
	}
}
