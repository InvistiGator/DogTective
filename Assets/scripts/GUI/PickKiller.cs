using UnityEngine;
using System.Collections;

public class PickKiller : MonoBehaviour {

	static public int randomizedKiller;
	static PickKiller killerInstance; 


	void Start(){
		if(killerInstance != null){
			GameObject.Destroy(gameObject);
		}
		else{
			GameObject.DontDestroyOnLoad(gameObject);
			killerInstance = this; 
		}

	}
	//the actual meto to pick the killer
	public int pickKillerRand(){
	//Random rnd = new Random();
		//generate a random number from 0 to 6
		//0 Doug, 1 Jade, 2 Norm, 3 Damina, 4 Tom, 5 Goldie, 6 Morgan
		randomizedKiller = Random.Range(0,7);
		//randomizedKiller = 4;
		return randomizedKiller;
	}

	public int getRandomizedKiller(){
		//return the int stored in randomizedKiller: int
		return randomizedKiller; 
	}
}
