using UnityEngine;

public class Player : MonoBehaviour
{
    //Declarations

    //Movement
    [SerializeField] private float speed;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float VerticallInput;
    [SerializeField] private float horizontalBound;
    [SerializeField] private float verticalBound;

    //Attack
    [SerializeField] private GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialize Values
        speed = 5;
        horizontalBound = 10;
        verticalBound = 5.3f;
    }

    // Update is called once per frame
    void Update()
    {

        //Limit movement area
        LimitMovement();

        //Player attack
        Attack();
    }

    void FixedUpdate()
    {
        //Move the player
        Movement();
    }

    //Move the player
    private void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        VerticallInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector3.up * Time.deltaTime * VerticallInput * speed);
    }

    //Limit movement area
    private void LimitMovement()
    {
        if (transform.position.x > horizontalBound)
        {
            transform.position = new Vector3(horizontalBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -horizontalBound)
        {
            transform.position = new Vector3(-horizontalBound, transform.position.y, transform.position.z);
        }
        if (transform.position.y > verticalBound)
        {
            transform.position = new Vector3(transform.position.x, verticalBound, transform.position.z);
        }
        if (transform.position.y < -verticalBound)
        {
            transform.position = new Vector3(transform.position.x, -verticalBound, transform.position.z);
        }
    }

    //Player attack
    private void Attack()
    {
        //Throw the bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }

    }
}
