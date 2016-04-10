using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class JadeEmotionController : MonoBehaviour {

	static Animator anim;
	public GameObject Jade;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();

		Jade.SetActive(true);

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
		Jade.SetActive(true);
	}
	public void exit(){
		Jade.SetActive(false);
	}
}
