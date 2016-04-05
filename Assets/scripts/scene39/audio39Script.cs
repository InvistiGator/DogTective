using UnityEngine;
using System.Collections;

public class audio39Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip knocking;
	public AudioClip doorOpeningQuickly;
	public AudioClip doorClosingQuickly;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}

	public void playKnocking() {
		audio.clip=knocking;
		audio.Play();
	}
	public void playDoorOpen() {
		audio.clip = doorOpeningQuickly;
		audio.Play();
	}
	public void playDoorClose() {
		audio.clip=doorClosingQuickly;
		audio.Play();
	}

}
