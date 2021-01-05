using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject obstacles;

    GameObject AI;

    // Start is called before the first frame update
    void Start()
    {

        print("Gameeeeeeeee");
   
        obstacles = Resources.Load("Prefabs/Square") as GameObject;

        for (int i = 0; i <= 5; i++)

        {
            Instantiate(obstacles, new Vector3(Random.Range(-47.0f, 47.0f), Random.Range(-47f, 47f), 0), Quaternion.identity); // y-47 47 x = Generating the 5 obsticles
        }

        AI = Resources.Load("Prefabs/AI") as GameObject;

        for (int i = 0; i <= 5; i++)

        {
            Instantiate(AI, new Vector3(Random.Range(-47.0f, 47.0f), Random.Range(-47f, 47f), 0), Quaternion.identity); // y-47 47 x = Generating the 5 obsticles
        }







    }




}
