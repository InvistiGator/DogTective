using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {
	//public AudioClip openTheme;
	public AudioSource source;
	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource>();
	}
	void Start(){
		source.Play();
		//source.Play(44100);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
