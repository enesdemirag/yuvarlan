using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    void Start()
    {
        GameObject ground = GameObject.Find("Ground");
        
        for(int i = 1; i < 17; i++) {
            string obs = "Obstacle" + i;
            GameObject obstacle = GameObject.Find(obs);
            
            float range = (obstacle.transform.localScale.x - ground.transform.localScale.x) / 2;
            obstacle.transform.position = new Vector3(Random.Range(-1 * range, range),
                                                      obstacle.transform.position.y,
                                                      obstacle.transform.position.z + Random.Range(-2, 2));
        }
    }
}
