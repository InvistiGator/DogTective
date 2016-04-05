using UnityEngine;
using System.Collections;

public class audio12Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip footsteps;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}

	public void playFootsteps() {
		audio.clip = footsteps;
		audio.Play();
	}

}
