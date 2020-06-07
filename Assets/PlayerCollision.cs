using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public int health = 3;
    public Text timeText;
    public Text hpText;
    public float time = 60;

    void Update() {
        time -= Time.deltaTime;
        if(time <= 0) {
            SceneManager.LoadScene(0);
        }
        timeText.text = time.ToString("0");
    }

    void OnCollisionEnter(Collision coll) {
        
        if(coll.collider.tag == "Obstacle") {
            health -= 1;
            hpText.text = health.ToString("0");
            Debug.Log(health.ToString());
            
            Destroy(coll.collider);
            
            movement.enabled = false;
            if (health == 0) {
                SceneManager.LoadScene(0);
            }
            movement.enabled = true;
        }
        else if(coll.collider.tag == "Target") {
            SceneManager.LoadScene(0);
        }
    }
}
