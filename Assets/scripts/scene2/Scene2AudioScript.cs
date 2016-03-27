using UnityEngine;
using System.Collections;

public class AudioScript_Scene2 : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip openTheme;
	public AudioClip decisionPrompt;
	public AudioClip decisionRes;
	public AudioClip bloodEvent;

	public AudioClip phoneVibration;
	public AudioClip DougTransition;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}
	public void playOpenTheme(){
        audio.clip = openTheme;
		audio.Play();
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
	public void playDougTransition(){
		audio.clip = DougTransition;
		audio.Play();	
	}
}
