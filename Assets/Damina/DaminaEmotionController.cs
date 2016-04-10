using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class DaminaEmotionController : MonoBehaviour {

	static Animator anim;
	public GameObject Damina;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	void Update(){

	}
	public void isIdle(){
		anim.SetTrigger("isIdle"); 
	}
	public void isSurprised(){
		anim.SetTrigger("isSuprised");
	}
	public void isSad(){
		anim.SetTrigger("isSad");
	}
	public void isHappy(){
		anim.SetTrigger("isHappy");
	}
	public void isAwk(){
		anim.SetTrigger("isAwk");
	}
	public void isAnnoyed(){
		anim.SetTrigger("isAnnoyed");
	}
	public void isAngry(){
		anim.SetTrigger("isAngry");
	}
	public void enter(){
		Damina.SetActive(true);
	}
	public void exit(){
		Damina.SetActive(false);
	}
}
