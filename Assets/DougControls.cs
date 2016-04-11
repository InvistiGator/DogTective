using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DougControls : MonoBehaviour {

	static Animator anim;
	public float speed = 1.0F;
	public float holder = 0;

	 public GameObject SceneHandlerObj;
        public SceneHandler sceneManagerScript;

        public scene2Manager scene2ManagerObj;
        public scene7Manager scene7ManagerObj;
    
        void Awake(){
            //finds the empty gameobject associated with sceneHandler
            SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
            //finds the script that is attached to the above gameobject
            sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
            if(SceneManager.GetActiveScene().name == "2"){
                scene2ManagerObj = scene2ManagerObj.GetComponent<scene2Manager>();
            }
            else if(SceneManager.GetActiveScene().name == "7"){
                scene7ManagerObj = scene7ManagerObj.GetComponent<scene7Manager>();
            }
         
        }

        
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal");

		Debug.Log(translation);
		Debug.Log(rotation);
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;

		if(translation>0 && rotation == 0){
			holder = 0;
		}
		else if(translation > 0 && rotation > 0){
			holder = 45;
		}
		else if(rotation > 0 && translation == 0){
			holder = 90;
		}
		else if (translation < 0 && rotation > 0){
			holder = 135;
		}
		else if(translation < 0 && rotation == 0){
			holder = 180;
		}
		else if(translation < 0 && rotation < 0){
			holder = 225;
		}
		else if(rotation < 0 && translation == 0){
			holder = 270;
		}
		else if(translation > 0 && rotation < 0){
			holder = 315;
		}
		transform.eulerAngles = new Vector3(0, holder, 0);
		if(translation >0){
			transform.Translate(0,0,translation);
		}
		else if(translation <0) {
			transform.Translate(0,0,translation * -1);
		}
		else if(rotation > 0){
			transform.Translate(0,0,rotation);
		}
		else{
			transform.Translate(0,0,rotation * -1);
		}
		if(translation != 0 || rotation != 0){
			anim.SetBool("isWalking", true);
		}
		else{
			anim.SetBool("isWalking", false);
		}
		
	}

	 void OnTriggerEnter(Collider evidence){
            if(SceneManager.GetActiveScene().name == "2"){
                if(evidence.gameObject.CompareTag("Evidence")){
                    sceneManagerScript.setEvidenceCollected3D(evidence.gameObject.name);

                    evidence.gameObject.SetActive (false);
                    //(scene2ManagerObj.scene2CanvasObj == true)
                    
                    scene2ManagerObj.walkedUpToCount++;
                   
                   /*
                    if(evidence.gameObject.name == "blood" && scene2ManagerObj.allEvidenceCollectd() ){
                        scene2ManagerObj.turnOffCongratsGUI();
                        scene2ManagerObj.displayGUI = true; 
                        scene2ManagerObj.displayDialogue();
                    }
                    
                    else if(evidence.gameObject.name == "blood"){
                        //pull up GUI for blood
                        scene2ManagerObj.turnOffCongratsGUI();
                        scene2ManagerObj.displayGUI = true; 
                        scene2ManagerObj.displayDialogue();
                    }
                    */
                    if(scene2ManagerObj.allEvidenceCollectd()){
                        scene2ManagerObj.turnOffCongratsGUI();
                        scene2ManagerObj.displayDialogue();
                        scene2ManagerObj.displayGUI = true; 
                    }
                    
                  
                    else{
                        scene2ManagerObj.displayCongratsGUI();
                        scene2ManagerObj.displayGUI = false; 
                    }
                    
                     //Destroy(evidence.gameObject);
                }
            }

            if(SceneManager.GetActiveScene().name == "7"){
                if(evidence.gameObject.CompareTag("Evidence")){
                    sceneManagerScript.setEvidenceCollected3D(evidence.gameObject.name);

                    evidence.gameObject.SetActive (false);
                    //(scene2ManagerObj.scene2CanvasObj == true)
                    
                    scene7ManagerObj.walkedUpToCount++;
                    
                    if(scene7ManagerObj.allEvidenceCollectd()){
                        scene7ManagerObj.turnOffCongratsGUI();
                        scene7ManagerObj.displayDialogue();
                        scene7ManagerObj.displayGUI = true; 
                    }
                    
                  
                    else{
                        scene7ManagerObj.displayCongratsGUI();
                        scene7ManagerObj.displayGUI = false; 
                    }
                }   
            }
        }
}
