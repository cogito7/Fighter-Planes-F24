using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider hitRate)
    {
        //player gains life when touching health pickup
        if (hitRate.tag == "Player")
        {
            GameObject.Find("Player(Clone)").GetComponent<Player>().GainALife();
            Destroy(this.gameObject);
        }      
    }
}
