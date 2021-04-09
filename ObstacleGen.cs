using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGen : MonoBehaviour
{
    public List<GameObject> Obstacles;

    private List<ObstacleBase> ObsBase;

    private bool canSpown = true;

    void Start()
    {

    }

    void Update()
    {
        if (canSpown == true)
        {
            StartCoroutine(ObsSpown());
        }
    }

    public IEnumerator ObsSpown()
    {
        canSpown = false;

        float time = Random.Range(0.5f, 1.5f);

        int currObsCount = Random.Range(1, 4);
        if (currObsCount == 1)                      //SpownTwoObstaclesIfPossible
        {

            float randomX = Random.Range(-2.1f, 2.1f);
            Obstacles[0].transform.position = new Vector3(randomX, 0.5f, 30f);
            Obstacles[0].GetComponent<ObstacleBase>().enabled = true;
            if (Obstacles[0].transform.position.x + 1.7f /*BallScale*/ + 1.5 /*ObsScale*/ < 2.1f /*EdgeOfRoad*/)
            {               
                Obstacles[1].transform.position = new Vector3(Obstacles[0].transform.position.x + 1.7f + 1.5f, 0.5f, 30f);
                Obstacles[1].GetComponent<ObstacleBase>().enabled = true;
                Obstacles.Remove(Obstacles[1]);
            }
            else if(Obstacles[0].transform.position.x - 1.7f /*BallScale*/ - 1.5 /*ObsScale*/ > -2.1f /*EdgeOfRoad*/)
            {
                Obstacles[1].transform.position = new Vector3(Obstacles[0].transform.position.x - 1.7f - 1.5f, 0.5f, 30f);
                Obstacles[1].GetComponent<ObstacleBase>().enabled = true;
                Obstacles.Remove(Obstacles[1]);
            }
            Obstacles.Remove(Obstacles[0]);
        }
        else                                       //SpownOneObstacle
        {
            float randomX = Random.Range(-2.1f, 2.1f);
            Obstacles[0].transform.position = new Vector3(randomX, 0.5f, 30f);
            Obstacles[0].GetComponent<ObstacleBase>().enabled = true;
            Obstacles.Remove(Obstacles[0]);            
        }
        yield return new WaitForSeconds(time);

        canSpown = true;
    }
}
