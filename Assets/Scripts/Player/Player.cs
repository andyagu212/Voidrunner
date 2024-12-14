using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

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
    [SerializeField] private GameObject rocket;
    [SerializeField] private List<GameObject> pooledRocket;
    [SerializeField] private GameObject rocketPoolContainer;
    private bool isRecharging;

    //Defense
    [SerializeField] private GameObject shield;
    private bool haveShied;

    //Game
    [SerializeField] private int life;
    [SerializeField] private SpriteRenderer shipSpriteRendrer;
    [SerializeField] private List<Sprite> shipSprites;

    //Audio
    [SerializeField] private AudioClip rocketAudioClip;
    [SerializeField] private AudioClip explosionAudioClip;

    //Instantiate pooledRocket
    private void Awake()
    {
        InstancePool(10);
        TurnOffPooledRocket();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialize Values
        speed = 5;
        horizontalBound = 10;
        verticalBound = 5.3f;
        life = 4;
    }

    // Update is called once per frame
    void Update()
    {

        //Limit movement area
        LimitMovement();

        //Player attack
        Attack();
    }

    //Movement
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
        if (transform.position.y > verticalBound - 1)
        {
            transform.position = new Vector3(transform.position.x, verticalBound - 1, transform.position.z);
        }
        if (transform.position.y < -verticalBound)
        {
            transform.position = new Vector3(transform.position.x, -verticalBound, transform.position.z);
        }
    }

    //Create rocket instances
    void InstancePool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject spawnObj = Instantiate(rocket, transform.position, rocket.transform.rotation);
            pooledRocket.Add(spawnObj);
            spawnObj.transform.SetParent(rocketPoolContainer.transform);
        }
    }

    //Turn off rocket instances
    void TurnOffPooledRocket()
    {
        foreach (var clon in pooledRocket)
        {
            clon.SetActive(false);
        }
    }

    //Player attack
    private void Attack()
    {
        if (Input.GetMouseButton(0) && !isRecharging)
        {
            isRecharging = true;

            //Select rocket to attack
            GameObject ObjectToActivate = GetOffObject();
            ObjectToActivate.transform.position = transform.position;
            GetOffObject().SetActive(true);

            //Play audio clip rocket
            AudioManager.Instance.PlaySFX(rocketAudioClip);

            //Rocket time to recharging
            StartCoroutine(RechargingTime());
        }
    }

    //Select rocket to attack
    private GameObject GetOffObject()
    {
        for (int i = 0; i < pooledRocket.Count; i++)
        {
            if (!pooledRocket[i].activeInHierarchy)
            {
                return pooledRocket[i];
            }
        }

        InstancePool(1);
        return pooledRocket.Last<GameObject>();
    }

    //Rocket time to recharging
    IEnumerator RechargingTime()
    {
        yield return new WaitForSeconds(1);
        isRecharging = false;
    }

    //Detect triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("ShieldPowerUp"))
        {
            //Activate shield
            shield.SetActive(true);
            haveShied = true;
        }  
    }

    //Detect collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            if (haveShied)
            {
                haveShied = false;
            }
            else
            {
                //Decrease life
                TakeDamage();
            }  
        }
    }

    //Decrease life
    private void TakeDamage()
    {
        life--; 

        if (life <= 0)
        {
            //Game over
            gameObject.SetActive(false);
            UIManager.Instance.GameOver();
        }

        else
        {
            //Play audio clip explosion
            AudioManager.Instance.PlaySFX(explosionAudioClip);

            //Decrease life
            UIManager.Instance.ChangeLife(life);
            shipSpriteRendrer.sprite = shipSprites[life - 1];
        }
    }
}
