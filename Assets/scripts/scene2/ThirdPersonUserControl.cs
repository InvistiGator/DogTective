using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

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

        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
#if !MOBILE_INPUT
			// walk speed multiplier
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }

        void OnTriggerEnter(Collider evidence){
            if(SceneManager.GetActiveScene().name == "2"){
                if(evidence.gameObject.CompareTag("Evidence")){
                    sceneManagerScript.setEvidenceCollected3D(evidence.gameObject.name);

                    evidence.gameObject.SetActive (false);
                    //(scene2ManagerObj.scene2CanvasObj == true)
                    
                    scene2ManagerObj.walkedUpToCount++;
                   
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
}