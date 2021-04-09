using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : MonoBehaviour
{
    public ObstacleGen ObsGen;

    void Update()
    {
        if (transform.position.z > -10)
        {
            transform.position = transform.position - new Vector3(0, 0, 10) * Time.deltaTime;
        }
        else if (transform.position.z <= -10)
        {
            ObsGen.Obstacles.Add(gameObject);
            GetComponent<ObstacleBase>().enabled = false;
        }
    }
}
