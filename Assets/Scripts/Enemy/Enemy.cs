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
            life--;
            CheckLife();
        }
    }

    private void CheckLife()
    {
        if(life <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
