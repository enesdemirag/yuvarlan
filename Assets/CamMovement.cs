using UnityEngine;

public class CamMovement : MonoBehaviour {
    
    public Transform ball;

    float curve(float x) {
        return (x - 0.3f) * (x - 0.3f) - 0.3f * x + 0.834f;
    }
    
    void LateUpdate() {
        transform.position = new Vector3(ball.transform.position.x,
                                         ball.transform.position.y + 0.45f,
                                         ball.transform.position.z - 2.0f);
    }
}
