using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using JetBrains.Annotations;

public class Player : MonoBehaviour
{
    //variables
    //1. access level: public or private
    //2. type: int (e.g., 2, 4, 123, 3456, etc.), float (e.g, 2.5, 3.67, etc.)
    //3. name: (1) start w/ lowercase (2) if it is multiple words, then the other words start with uppercase and written together
    //4. optional: give it an initial value

    public float horizontalInput;
    private float verticalInput;
    private float speed;
    public int lives;
    public float minY;
    public GameObject bullet;
    public GameManager gameManager;
    private int shooting;

    // Start is called before the first frame
    void Start()
    {
        speed = 6f;
        lives = 3;//start lives at 3
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        shooting = 1;

    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Shooting();
    }

    void Moving()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        //if my x position is bigger than 11.5f then I am outside the screen from the right 
        if (transform.position.x > 11.5f || transform.position.x <= -11.5f)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 8f || transform.position.y <= -8f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, transform.position.z);
        }


        //clamp player to bottom half of screen 
        float clampedY = Mathf.Clamp(transform.position.y, -8f, minY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);




    }

    void Shooting()
    {
            if (Input.GetKeyDown(KeyCode.Space))
             {
                    switch (shooting)
                    {
                        case 1:
                                //if SPACE key is pressed create a bullet; what is a bullet?
                                //create a bullet object at my position with my rotation
                                Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                            
                            break;
                        case 2:

                                //create a bullet object at my position with my rotation
                                Instantiate(bullet, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.identity);
                                Instantiate(bullet, transform.position + new Vector3(0.5f, 1, 0), Quaternion.identity);
                            
                            break;
                        case 3:

                            
                                //create a bullet object at my position with my rotation
                                Instantiate(bullet, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.Euler(0, 0, 30f));
                                Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                                Instantiate(bullet, transform.position + new Vector3(0.5f, 1, 0), Quaternion.Euler(0, 0, -30f));

                            break;
                    }
             }   
                


    }

    public void LoseALife()
    {
        //decrease lives count
        lives--;

        //check if lives have reached zero
        if (lives == 0)
        {
            gameManager.GameOver();
            Destroy(this.gameObject);
        }

    }

    public void GainALife()
    {
        //increase life count
        lives++;

        if (lives > 3)
        {
            lives--;
        }
    }
    /*
    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(3f);
        speed = 6f;
        gameManager.UpdatePowerupText("");
    }
    */

    IEnumerator ShootingPowerDown()
    {
        yield return new WaitForSeconds(4f);
        shooting = 1;
        gameManager.UpdatePowerupText("");
    }

    private void OnTriggerEnter(Collider hitRate)
    {

        if (hitRate.tag == "Powerup")
        {
            gameManager.PlayPowerUp();
            //gameManager.UpdatePowerupText("powerup");
            int powerupType = Random.Range(1, 5);//int 1,2,3, or 4

            switch(powerupType)
            {


                case 1:
                    //double shot
                    shooting = 2;
                    gameManager.UpdatePowerupText("Picked up Double Shot!");
                    StartCoroutine(ShootingPowerDown());
                    break;

                case 2:
                    //triple shot
                    shooting = 3;
                    gameManager.UpdatePowerupText("Picked up Triple Shot!");
                    StartCoroutine(ShootingPowerDown());
                    break;

                case 3:
                    //shield
                    gameManager.UpdatePowerupText("Picked up SHIELD");
                    break;

            }
            Destroy(hitRate.gameObject);
        }
    }
 

}



    




