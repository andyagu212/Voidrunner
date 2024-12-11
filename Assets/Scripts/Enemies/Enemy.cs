using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Declarations

    //Movement
    [SerializeField] private float speed;
    [SerializeField] private int life;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //Enemy movement
        Movement();
    }

    //Enemy movement
    private void Movement()
    {

    }

    //Detect damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerRocket"))
        {
            //Decrease life
            TakeDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Shield"))
        {
            //Decrease life
            TakeDamage();
        }
    }

    //Decrease life
    private void TakeDamage()
    {
        life--;

        if (life <= 0)
        {
            //Disable enemy
            gameObject.SetActive(false);
        }
    }
}
