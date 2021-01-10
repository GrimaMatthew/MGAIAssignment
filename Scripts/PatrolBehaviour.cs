using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PatrolBehaviour : MonoBehaviour
{

    public List<Transform> waypoint;

    Seeker seeker;

    Path pathToFollow;

  



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(updateGridGraph());

        seeker = GetComponent<Seeker>();


        //The path to follow between our AI and our Target is set here
        pathToFollow = seeker.StartPath(transform.position, waypoint[9].position);


        //moving the greenbox. runs indefinetly 
        StartCoroutine(movePlayer());



    }


    IEnumerator updateGridGraph()
    {
        while (true)
        {
            AstarPath.active.Scan();
            yield return null;
        }

    }



    //the code that is going to move my target.
    IEnumerator movePlayer()
    {


        print("Tomatoeesss");
 

        //Starting position , the list of positions & a boolean paramtere stating if the path is looped
        StartCoroutine(movePlayer(this.transform, waypoint, true));


        yield return null;

    }



   

    IEnumerator movePlayer(Transform t, List<Transform> points, bool loop)
    {

        print("Tomatoeesss");
        if (loop) // need to run idefinitely 
        {

            while (true)
            {
                List<Transform> forwardpoints = points;

                foreach (Transform p in forwardpoints)
                {
                    while (Vector3.Distance(t.position, p.position) > 0.5f)
                    {
                        t.position = Vector3.MoveTowards(t.position, p.position, 1f);
                        Debug.Log(p.position);/**/
                        pathToFollow = seeker.StartPath(t.position, waypoint[9].position);
                        yield return new WaitForSeconds(0.2f);
                    }
                }

                //reverse point supplied here 1-5 reverse 5-1
                forwardpoints.Reverse();
                yield return null;

            }
        }
        else
        {
            foreach (Transform pne in points)
            {
                while (Vector3.Distance(t.position, pne.position) > 0.5f)
                {
                    t.position = Vector3.MoveTowards(t.position, pne.position, 1f);
                    /**/
                    yield return new WaitForSeconds(0.2f);
                }
            }
            yield return null;
        }


    }

  




}




   
