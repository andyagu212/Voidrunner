using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
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
            int classEnemy = Random.Range(0, 2);

            if (classEnemy == 0)
            {
                ActivateWaveScout();
            }
            else
            {
                ActivateWaveFighter();
            }

            yield return new WaitForSeconds(5);
        }
    }

    //ActivateWaveScout
    private void ActivateWaveScout()
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

    //ActivateWaveFighter
    private void ActivateWaveFighter()
    {
        int numberOfEnemies = Random.Range(0, 5);

        switch (numberOfEnemies)
        {
            case 0:
                enemies[6].SetActive(true);
                break;

            case 1:
                enemies[6].SetActive(true);
                enemies[8].SetActive(true);
                break;

            case 2:
                enemies[5].SetActive(true);
                enemies[6].SetActive(true);
                enemies[9].SetActive(true);
                break;

            case 3:
                enemies[5].SetActive(true);
                enemies[7].SetActive(true);
                enemies[8].SetActive(true);
                enemies[9].SetActive(true);
                break;

            case 4:
                enemies[5].SetActive(true);
                enemies[7].SetActive(true);
                enemies[6].SetActive(true);
                enemies[8].SetActive(true);
                enemies[9].SetActive(true);
                break;
        }
    }
}