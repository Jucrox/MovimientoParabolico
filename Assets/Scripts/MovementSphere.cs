using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSphere : MonoBehaviour
{
    public Interface interfaceMS;
    public DistanceCollision distanceCollisionMS;
    public Chronometer chronometerMS;

    public GameObject sphere;
    public GameObject thrower;

    private float speedMS;
    public float angleMS;
    private float distanceMS;
    private float timeMS;

    public float realDistance;
    public float angleRadianes;
    public float errorTolerance;

    public bool simulationBool;
    public bool timeBool;
  
    // Start is called before the first frame update
    void Start()
    {
        simulationBool = false;
        interfaceMS = interfaceMS.GetComponent<Interface>();
        distanceCollisionMS = distanceCollisionMS.GetComponent<DistanceCollision>();
        chronometerMS = chronometerMS.GetComponent<Chronometer>();
        
    }

    // Update is called once per frame
    void Update(){
        distanceCollisionMS.VerifyCollision2();
        speedMS = interfaceMS.speed * 10;
        angleMS = interfaceMS.angle;
        distanceMS = interfaceMS.distance;
        timeMS = chronometerMS.timeCollision;

        Debug.Log("Tiempo " + timeMS);

        if(simulationBool == true){
            
            transform.LookAt(thrower.transform);
            sphere.GetComponent<Rigidbody>().AddForce(transform.forward * speedMS);
            simulationBool = false;
            
        }

        DistanceCalculate();
        
    }

    public void Simulation(){
        transform.Rotate(-angleMS, 0, 0);
        simulationBool = true;
        timeBool = true;
        
    }

    public void DistanceCalculate(){
        if(distanceCollisionMS.trueCollision == true){
            angleRadianes = angleMS * (Mathf.PI / 180);
            realDistance = ( interfaceMS.speed * Mathf.Cos(angleRadianes) *  timeMS );
            Debug.Log("Distancia recorrida " + realDistance);
            timeBool = false;
            ErrorTolerance();
        }
    }

    public void ErrorTolerance(){
        errorTolerance = Mathf.Abs(100 - ((realDistance * 100) / distanceMS));
        Debug.Log("Porcentaje de error " + errorTolerance + "%");
        interfaceMS.FinalScore();
    }

}
