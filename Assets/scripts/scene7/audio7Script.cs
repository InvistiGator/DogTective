using UnityEngine;
using System.Collections;

public class audio7Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip decisionPrompt;
	public AudioClip decisionRes;
	public AudioClip bloodEvent;

	public AudioClip phoneVibration;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}
	public void playDecisionPrompt(){
		audio.clip = decisionPrompt;
		audio.Play();
	}
	public void playDecisionRes(){
		audio.clip = decisionRes;
		audio.Play();
	}
	public void playBloodEvent(){
		audio.clip = bloodEvent;
		audio.Play();	
	}
	public void playPhoneVibration(){
		audio.clip = phoneVibration;
		audio.Play();	
	}
	
}
