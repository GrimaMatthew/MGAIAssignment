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

       

        AI = Resources.Load("Prefabs/AI") as GameObject;

       





    }


    private void Update()
    {
        
    }

    public void gStarter()
    {
        for (int i = 0; i <= 5; i++)

        {
            Instantiate(AI, new Vector3(Random.Range(-40.0f, 42.0f), Random.Range(-34f, 47f), 0), Quaternion.identity); // y-47 47 x = Generating the 5 obsticles
        }

        for (int i = 0; i <= 5; i++)

        {
            Instantiate(obstacles, new Vector3(Random.Range(-47.0f, 47.0f), Random.Range(-47f, 47f), 0), Quaternion.identity); // y-47 47 x = Generating the 5 obsticles
        }



    }

    public void addAI()
    {
        Instantiate(AI, new Vector3(Random.Range(-40.0f, 42.0f), Random.Range(-34f, 47f), 0), Quaternion.identity);

    }

    public void addObstacles()
    {
        Instantiate(obstacles, new Vector3(Random.Range(-40.0f, 42.0f), Random.Range(-34f, 47f), 0), Quaternion.identity);
    }

    public void scannerBo()
    {
        AstarPath.active.Scan();
    }







}
