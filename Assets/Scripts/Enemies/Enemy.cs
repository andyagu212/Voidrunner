using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Declarations

    //Movement
    [SerializeField] protected float speed;
    [SerializeField] private int life;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float horizontalBound;

    //Audio
    [SerializeField] private AudioClip explosionAudioClip;

    //Save spawn position
    private void Awake()
    {
        //Initialize Values
        spawnPosition = transform.position;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Reset initial position
    private void OnEnable()
    {
        transform.position = spawnPosition;
    }

    //Movement
    void FixedUpdate()
    {
        //Enemy movement
        Movement();
    }

    //Enemy movement
    public virtual void Movement()
    {
        if(transform.position.x <= -horizontalBound)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    //Detect damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerRocket"))
        {
            //Decrease life
            collision.gameObject.SetActive(false);
            TakeDamage();
        }
    }

    //Detect collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Shield"))
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
            UIManager.Instance.IncreaseScore();

            //Play audio clip explosion
            AudioManager.Instance.PlaySFX(explosionAudioClip);

            //Disable enemy
            gameObject.SetActive(false);
        }
    }
}
