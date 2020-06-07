using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    
    public Rigidbody ball;

    public SphereCollider sphereCol;
    public BoxCollider boxCol;

    public Mesh sphere;
    public Mesh cube;
    public MeshFilter meshFilter;

    public float forwardForce = 850f;
    public float sideForce = 10f;
    public bool canJump = false;
    public float jumpForce = 0.5f;

    void Start() {
        Debug.Log("Game Started");
    }

    void swapShape() {
        if(sphereCol.enabled) {
            Mesh mesh = Instantiate (cube) as Mesh;
            meshFilter.sharedMesh = mesh;
            forwardForce = 400f;
        }
        else {
            Mesh mesh = Instantiate (sphere) as Mesh;
            meshFilter.sharedMesh = mesh;
            forwardForce = 850f;
        }
    }

    void Update() {
        if(Input.GetKeyUp(KeyCode.Space)) {
            if(transform.position.y < 0.35) { canJump = true; }
        }
        else if(Input.GetKeyUp(KeyCode.Return)) {
            swapShape();
            boxCol.enabled = !boxCol.enabled;
            sphereCol.enabled = !sphereCol.enabled;
        }
        else if(Input.GetKeyUp(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }
    }
    
    void FixedUpdate() {
        if(Input.GetKey(KeyCode.UpArrow)) {
            ball.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow)) {
            ball.AddForce(sideForce * Time.deltaTime , 0, 0, ForceMode.VelocityChange);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) {
            ball.AddForce(-1 * sideForce * Time.deltaTime , 0, 0, ForceMode.VelocityChange);
        }
        else if(canJump) {
            canJump = false;
            Debug.Log("Jump");
            ball.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        
    }
}
