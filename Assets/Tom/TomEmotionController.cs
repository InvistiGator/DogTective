using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class TomEmotionController : MonoBehaviour {

	static Animator anim;
	public GameObject Tom;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();

		Tom.SetActive(true);

	}
	void Update(){

	}
	public void isIdle(){
		anim.SetTrigger("isIdle"); 
	}
	public void isSuprised(){
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
		Tom.SetActive(true);
	}
	public void exit(){
		Tom.SetActive(false);
	}
}
