using UnityEngine;
using System.Collections;

public class audio15Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip knucklesCracking;
	public AudioClip var213;
	public AudioClip click;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}

	public void playKnucklesCracking() {
		audio.clip = knucklesCracking;
		audio.Play();
	}

	public void playVar213() {
		audio.clip = var213;
		audio.Play();
	}

	public void playClick() {
		audio.clip = click;
		audio.Play();
	}

}
