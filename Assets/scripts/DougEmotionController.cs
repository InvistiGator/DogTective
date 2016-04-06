using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class DougEmotionController : MonoBehaviour {

	static Animator anim;
	public scene1Manager sceneMan;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	void Update(){
		if(sceneMan.i==sceneMan.iwithClockTick){
			triggerDisbelief();
		}
		if(sceneMan.i==sceneMan.iwithDoorOpen){
			triggerRejected();
		}
		if(sceneMan.i==sceneMan.iwithDoorClose){
			triggerDisbelief();
		}
		if(sceneMan.i==sceneMan.iwithPhoneVibrating){
			triggerExcited();
		}

	}
	public void triggerExcited(){
		anim.SetTrigger("isExcited"); 
	}
	public void triggerRejected(){
		anim.SetTrigger("isRejected");
	}
	public void triggerDisbelief(){
		anim.SetTrigger("isDisbelief");
	}
}
