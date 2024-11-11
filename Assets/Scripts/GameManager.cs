using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Player player;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject lifePickup;

    private int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        //update the player
        player = Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateEnemy2", 3f, 5f);
        InvokeRepeating("CreateEnemy3", 5f, 2f);
        InvokeRepeating("CreateCoin", 5f, 4f);
        InvokeRepeating("CreateLifePickup", 5f, 10f );
        score = 0;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + player.lives;
    }

    // Update is called once per frame
    void Update()
    {
        //update lives text
        livesText.text = "Lives: " + player.lives;
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

    void CreateLifePickup()
    {
        Instantiate(lifePickup, new Vector3(Random.Range(-8f, 8f), Random.Range(-6f, 1f), transform.position.z), Quaternion.identity);
    }
   
    public void EarnScore(int scoreCount)
    {
        score = score + scoreCount;
        scoreText.text = "Score: " + score;
    }
    void CreateCoin()
    {
        Vector2 boundsCoin= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector3 scale = coin.transform.localScale;
        Instantiate(coin, new Vector3(Random.Range(-boundsCoin.x - scale.x, boundsCoin.x + scale.x), Random.Range(-scale.y, boundsCoin.y + scale.y), transform.position.z), Quaternion.identity);
    }

}
