using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chronometer : MonoBehaviour
{
    public MovementSphere movementSphereC;
    public DistanceCollision distanceCollisionC;
    public Interface interfaceC;

    public float time;
    public float timeCollision;

    // Start is called before the first frame update
    void Start()
    {
        movementSphereC = movementSphereC.GetComponent<MovementSphere>();
        distanceCollisionC = distanceCollisionC.GetComponent<DistanceCollision>();
        interfaceC = interfaceC.GetComponent<Interface>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementSphereC.timeBool == true){
            time += Time.deltaTime;
        }else if(distanceCollisionC.countCollider == 2){
            timeCollision = time;
        }
        
    }

    public void ResetTime(){
        time = 0;
    }
}
