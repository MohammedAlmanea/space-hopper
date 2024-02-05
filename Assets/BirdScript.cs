using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigbody;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float fallRotationSpeed = 50f; // Control the speed of rotation when falling

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigbody.velocity = Vector2.up * 7;
        }

        if (transform.position.y >= 7 || transform.position.y <= -7)
        {
            logic.gameOver();
            birdIsAlive = false;
        }

        if (myRigbody.velocity.y < 0 && birdIsAlive)
        {
            transform.eulerAngles += Vector3.forward * Time.deltaTime * -fallRotationSpeed;
        }
        else if (myRigbody.velocity.y > 0 && birdIsAlive)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
