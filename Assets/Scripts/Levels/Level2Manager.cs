using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    //Declarations

    //Game
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private GameObject shieldPowerUp;
    [SerializeField] private GameObject rocketPowerUp;

    //Audio
    [SerializeField] private AudioClip music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Background music
        AudioManager.Instance.PlayMusic(music);

        //Star generations of enemies and power ups
        StartCoroutine(TimeBetweenWaves());
        StartCoroutine(TimeBetweenPowerUp());
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
        GameManager.Instance.ChangeScene(3);
    }

    //TimeBetweenPowerUp
    IEnumerator TimeBetweenPowerUp()
    {
        int powerUp = Random.Range(0, 2);
        for (int i = 0; i < 2; i++)
        {
            switch (powerUp)
            {
                case 0:
                    shieldPowerUp.transform.position = SelectRandomPosition();
                    shieldPowerUp.SetActive(true);
                    break;

                case 1:
                    rocketPowerUp.transform.position = SelectRandomPosition();
                    rocketPowerUp.SetActive(true);
                    break;
            }

            yield return new WaitForSeconds(20);
        }
        GameManager.Instance.ChangeScene(2);
    }

    //Select random position for the power ups
    private Vector2 SelectRandomPosition()
    {
        return new Vector2(Random.Range(-10f, 10f), Random.Range(-5.3f, 4.3f));
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
