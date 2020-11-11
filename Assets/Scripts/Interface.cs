using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    
    public MovementSphere movementSphereI;
    public Chronometer chronometerI;
    public DistanceCollision distanceCollisionI;

    public GameObject canvasInitialValues;
    public GameObject imageFinalScore;

    public InputField inputFieldSpeed;
    public InputField inputFieldAngle;
    public InputField inputFieldDistance;
    public Text textAdvice;
    public Text textAdviceInitial;
    
    public float speed;
    public float angle;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        movementSphereI = movementSphereI.GetComponent<MovementSphere>();
        chronometerI = chronometerI.GetComponent<Chronometer>();
        distanceCollisionI = distanceCollisionI.GetComponent<DistanceCollision>();
        canvasInitialValues.SetActive(true);
        imageFinalScore.SetActive(false);
        //canvasFinalScore.GetComponent<Canvas>().enabled = false; 
        speed = 0;
        angle = 0;
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void initializeSimulation(){
        
        if(inputFieldSpeed.text == "" || inputFieldAngle.text == "" || inputFieldDistance.text == ""){
            //Debug.Log("COMPLETE TODOS LOS CAMPOS");
            textAdviceInitial.text = "COMPLETE TODOS LOS CAMPOS";
        }else{
            speed = float.Parse(inputFieldSpeed.text);
            angle = float.Parse(inputFieldAngle.text);
            distance = float.Parse(inputFieldDistance.text);

            if(speed >= 0){
                if(angle >= 0 && angle <=90){
                    StartCoroutine(ToMovementSphere());
                }else{
                    textAdviceInitial.text = "DIGITE VALORES ENTRE 0 Y 90";
                    //Debug.Log("DIGITE VALORES ENTRE 0 Y 90");
                }
            }else{
                textAdviceInitial.text = "DIGITE VALORES POSITIVOS EN LA VELOCIDAD";
                //Debug.Log("DIGITE VALORES POSITIVOS");
            }
            
        }
         
    }

    public void FinalScore(){
        imageFinalScore.SetActive(true);
        if(movementSphereI.errorTolerance <= 5f){
            textAdvice.text = "FELICITACIONES";
        }else{
            textAdvice.text = "LA DISTANCIA INGRESADA NO ES CORRECTA";
        }
        StartCoroutine(ResetScene());
    }

    IEnumerator ToMovementSphere(){
        yield return new WaitForSeconds(1f);
        movementSphereI.Simulation();
        yield return new WaitForSeconds(0.1f);
        canvasInitialValues.GetComponent<Canvas>().enabled = false; 
    }
    IEnumerator ResetScene(){
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
    public void ResetScene2(){
        SceneManager.LoadScene(0);
    }
}
