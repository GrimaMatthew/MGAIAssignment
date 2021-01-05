using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoid : MonoBehaviour
{

    GameObject[] AI; // an array which will store AI GameObjects


    // Start is called before the first frame update
    void Start()
    {
        AI = GameObject.FindGameObjectsWithTag("AI"); // To load all of the AI gameobject

        
    }

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject i in AI) { // traversing through the ai array

            if(i != gameObject)
            {
                float aiAvoid = Vector3.Distance(i.transform.position, this.transform.position); // the distance between the different aiS as i gets the position of all the other ais while this gets the position of this script on the object
                
                if(aiAvoid <= 6.5f)
                {
                    print("TOO Close");
                    Vector3 dir = transform.position - i.transform.position;
                    transform.Translate(dir * 0.4f);
                }

            }

        }
        
    }
}
