using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneSelection : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneSelectionScript;

	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneSelectionScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
		// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool lookForEvidence(string evidence_){
		for(int i=0; i< sceneSelectionScript.CollectedEvidenceString.Length; i++){
			if(sceneSelectionScript.CollectedEvidenceString[i] == evidence_){
				return true;
			}
		}

		return false;
	}
	//====Navigation Game Play logic ===============//
	public void navToDoug(){
		if(sceneSelectionScript.userVisited[1] && lookForEvidence("blood")){
				SceneManager.LoadScene(6);
				Debug.Log("Current SceneInstance.userVisited[1]:  ");
				Debug.Log(sceneSelectionScript.userVisited[1]);
		}
	}

	public void navToNorm(){
		
	}

	public void navToGoldie(){
		
	}

	public void navToPolice(){
		
	}

	public void navToSallon(){
		
	}

	public void navToLawOffice(){
		
	}

}
