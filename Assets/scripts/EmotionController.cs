using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class EmotionController : MonoBehaviour {

	static Animator anim;
	public scene1Manager sceneMan;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	void Update(){
		if(sceneMan.i==sceneMan.iwithClockTick){
			triggerLaugh();
		}
		if(sceneMan.i==sceneMan.iwithDoorOpen){
			triggerAngry();
		}
		if(sceneMan.i==sceneMan.iwithDoorClose){
			triggerIdle();
		}
		if(sceneMan.i==sceneMan.iwithPhoneVibrating){
			triggerLaugh();
		}

	}
	public void triggerLaugh(){
		anim.SetTrigger("isLaughing"); 
	}
	public void triggerAngry(){
		anim.SetTrigger("isAngry");
	}
	public void triggerIdle(){
		anim.SetTrigger("isIdle");
	}
}
