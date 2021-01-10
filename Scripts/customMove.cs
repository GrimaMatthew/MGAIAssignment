using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class customMove : MonoBehaviour
{
    Seeker seeker;


    //This stores our path data
    Path pathToFollow;



    //Theis is where we will set up a refernce for our target which we will later use to get its position

    Transform target;

    void Start()
    {
        AstarPath.active.Scan();
        target = GameObject.FindGameObjectWithTag("Target").transform;
        
        print("Moveeeeeeee");
        StartCoroutine(updateGridGraph()); // If User has button to insert more obstacles we need to update the path constantly 

        //Setting up the seeker which will find our path towards the enemy
        seeker = GetComponent<Seeker>(); 

      
        //The path to follow between our AI and our Target is set here
        pathToFollow = seeker.StartPath(transform.position, target.position);


        //The method moveTowardsEnemy will move our Ai toward the Enemy  using the path above
        StartCoroutine(moveTowardsEnemy(this.transform));// WE are getting the transform of the object which has this script attached to it.

       
    }

   



    IEnumerator updateGridGraph()
    {
        while (true)
        {
            AstarPath.active.Scan();
            yield return null;
           

        }

    }



    IEnumerator moveTowardsEnemy(Transform t) //  the transform we will use will be for this.gameobject
    {
        while (true) //infinite loop
        {
            List<Vector3> posns = pathToFollow.vectorPath; // Creating a list of vector 3 // .vectorPath - gets our pathtoFollow and converts the path into vector 3  
         
            for (int counter = 0; counter < posns.Count; counter++)  // a for loop traversing the posns list .count counting the postions in posns

            {
                while (Vector3.Distance(t.position, posns[counter]) >= 0.5f) // check the position of the ai and using the counter as an 
                {                                                            // index we will check  the positions of the two objects.
                                                                             // Once the objects are 0.5f away the while loop will stop

                    t.position = Vector3.MoveTowards(t.position, posns[counter], 1f); // Move towards moves the Ai towards the points(Vector) in the list posns
                    yield return new WaitForSeconds(0.2f);// the wait allows us to move one box at a time. 
                    pathToFollow = seeker.StartPath(t.position, target.position);//path is destoryed as the ai goes through it as otherswise the path will still be avialble
                                                                                 // and the ai will not stop it will follow the path back once it is completed.
                    yield return seeker.IsDone();// isDone check if the current path is done calculating
                   
                    
                }
               
            }
            yield return null;
        }
    }

   

}

    





