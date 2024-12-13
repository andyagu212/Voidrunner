using UnityEngine;

public class Rocket : MonoBehaviour
{
    //Declarations

    //Movement
    [SerializeField] private float speed;
    [SerializeField] private float horizontalBound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 9;
        horizontalBound = 11;
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
        //Move the rocket
        Movement();
    }

    //Move rocket to right
    private void Movement()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    //Limit movement area
    private void LimitMovement()
    {
        if (transform.position.x > horizontalBound)
        {
            gameObject.SetActive(false);
        }
    }
}
