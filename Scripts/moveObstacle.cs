using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObstacle : MonoBehaviour
{

    public List<Transform> waypoints;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveMe());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator moveMe()
    {
        while(true)
        {
            
           

            this.transform.position = new Vector3(Random.Range(-20f,50f), Random.Range(-20f, 50f), 1);
            yield return new WaitForSeconds(5f);

            
      
        }
      
    }


}
