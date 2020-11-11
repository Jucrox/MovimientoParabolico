using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCollision : MonoBehaviour
{
    public Chronometer chronometerDC;
    public Interface interfaceDC;
    public MovementSphere movementSphereDC;

    public int countCollider;
    private float distanceSimulation;

    private float speedDC;
    private float angleDC;
    private float timeDC;

    public bool trueCollision = false;

    //public MovementSphere movementSphereDC;
    public void OnCollisionEnter(Collision col){
        
        chronometerDC = chronometerDC.GetComponent<Chronometer>();
        /* interfaceDC = interfaceDC.GetComponent<Interface>();
        movementSphereDC = movementSphereDC.GetComponent<MovementSphere>();
        angleDC = interfaceDC.angle; */
      
        if(col.collider.name == "Floor"){
            countCollider ++;
            VerifyCollision2();
        }
    }
    public void VerifyCollision2(){
        
        if(countCollider >= 2){
            trueCollision = true;
            
        } 
    }

    public void ResetCount(){
        countCollider = 0;
        chronometerDC.ResetTime();
    }

}
