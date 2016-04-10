using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class DaminaEmotionController : MonoBehaviour {

	static Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	void Update(){

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
