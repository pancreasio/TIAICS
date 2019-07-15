using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text scoreText, timeText;
    public bool levelEnded;
    private float lastWaveTime, levelTime;
    private int deadEnemies, totalEnemies;
    private GameManager gameManager;
    private GameObject[] enemyArray;
    private List<GameObject> enemyList, toDelete;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = enemyArray.Length;
        deadEnemies = 0;
        Cursor.visible = false;
        gameManager.UpdateCurrent();
        gameManager.SetRetryLevel();
        enemyList = new List<GameObject>();
        toDelete = new List<GameObject>();
        foreach (GameObject enemy in enemyArray)
        {
            enemyList.Add(enemy);
        }
    }

    private void Update()
    {
        levelTime += Time.deltaTime;
        foreach (GameObject enemy in enemyList)
        {
            if (enemy == null)
            {
                deadEnemies++;
                GameManager.score += 100;
                toDelete.Add(enemy);
            }
        }

        foreach (GameObject enemy in toDelete)
        {
            enemyList.Remove(enemy);
        }


        if (deadEnemies >= totalEnemies)
        {
            NextLevel();
        }
        scoreText.text = "Score: " +  Mathf.Round(GameManager.score).ToString() + " UR$$";
        timeText.text = "Time: " + Mathf.Round(levelTime).ToString() + "s";
    }

    private void NextLevel()
    {
        gameManager.NextScene();
    }

    public void GameOver()
    {
        gameManager.GameOver();
    }
}