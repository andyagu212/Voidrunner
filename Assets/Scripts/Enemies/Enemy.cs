using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Declarations

    //Movement
    [SerializeField] protected float speed;
    [SerializeField] private int life;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float horizontalBound;

    //Collider
    [SerializeField] private Collider2D colliderEnemy;

    //Audio
    [SerializeField] private AudioClip explosionAudioClip;

    //Animation
    [SerializeField] private Animator animator;

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

        //Active collider
        colliderEnemy.enabled = true;

        //Disable destruction animation
        animator.SetBool("isDestroyed", false);
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

            //Activate destruction animation
            animator.SetBool("isDestroyed", true);

            //Disable collider
            colliderEnemy.enabled = false;

            //Disable enemy
            StartCoroutine(TimeToDisable());
        }
    }

    IEnumerator TimeToDisable()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        
        if(gameObject.name == "EnemyDreadnought")
        {
            UIManager.Instance.Victory();
        }
    }
}
