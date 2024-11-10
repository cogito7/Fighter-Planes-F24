using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    private int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateEnemy2", 3f, 5f);
        InvokeRepeating("CreateEnemy3", 5f, 2f);
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 8f, transform.position.z), Quaternion.identity);
    }

    void CreateEnemy2()
    {
        Instantiate(enemy2, new Vector3(Random.Range(-9f, 0f), 8f, transform.position.z), Quaternion.identity);
    }

    void CreateEnemy3()
    {
        Instantiate(enemy3, new Vector3(9f, Random.Range(-6f, 1f), transform.position.z), Quaternion.identity);
    }
    public void EarnScore(int scoreCount)
    {
        score = score + scoreCount;
        scoreText.text = "Score: " + score;
    }
}
