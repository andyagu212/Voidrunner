using UnityEngine;

public class EnemyDreadnought : Enemy
{
    //Declarations

    //Movement
    [SerializeField] private float verticalBound;
    private bool moveUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Limit movement area
        LimitMovement();
    }

    //Movement
    void FixedUpdate()
    {
        //Enemy movement
        Movement();
    }

    //Enemy movement
    public override void Movement()
    {
        if (moveUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (!moveUp)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }

    //Limit movement area
    private void LimitMovement()
    {
        if (transform.position.y > verticalBound - 1 && moveUp)
        {
            moveUp = false;
            transform.position = new Vector3(transform.position.x, verticalBound - 1, transform.position.z);
        }
        if (transform.position.y < -verticalBound && !moveUp)
        {
            moveUp = true;
            transform.position = new Vector3(transform.position.x, -verticalBound, transform.position.z);
        }
    }
}
