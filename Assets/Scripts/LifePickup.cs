using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider playerHit)
    {
        //player gains life when touching health pickup
        if (playerHit.tag == "Player" && player.lives < 3)
        {
            GameObject.Find("Player(Clone)").GetComponent<Player>().GainALife();
            Destroy(this.gameObject);
        }
        else
        {
           Destroy(this.gameObject); 
        }

        
    }
}
