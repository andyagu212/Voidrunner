using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    //Declarations

    //Game
    [SerializeField] private List<GameObject> enemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TimeBetweenWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //TimeBetweenWaves
    IEnumerator TimeBetweenWaves()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 11; i++)
        {
            ActivateWave();
            yield return new WaitForSeconds(5);
        }
        SpawnBoss();
    }

    //ActivateWave
    private void ActivateWave()
    {
        int numberOfEnemies = Random.Range(0, 5);

        switch (numberOfEnemies)
        {
            case 0:
                enemies[2].SetActive(true);
                break;

            case 1:
                enemies[1].SetActive(true);
                enemies[3].SetActive(true);
                break;

            case 2:
                enemies[0].SetActive(true);
                enemies[2].SetActive(true);
                enemies[4].SetActive(true);
                break;

            case 3:
                enemies[0].SetActive(true);
                enemies[1].SetActive(true);
                enemies[3].SetActive(true);
                enemies[4].SetActive(true);
                break;

            case 4:
                enemies[0].SetActive(true);
                enemies[1].SetActive(true);
                enemies[2].SetActive(true);
                enemies[3].SetActive(true);
                enemies[4].SetActive(true);
                break;
        }
    }

    //SpawnBoss
    private void SpawnBoss()
    {

    }
}
