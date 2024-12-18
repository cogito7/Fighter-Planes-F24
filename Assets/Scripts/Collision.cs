using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider hitRate)
    {
        //player loses a life when hit by an enemy
        if (hitRate.tag == "Player")
        {
            GameObject.Find("Player(Clone)").GetComponent<Player>().LoseALife();
            Destroy(this.gameObject);

        }
        //player gains a score point when a weapon hits an enemy
        if (hitRate.tag == "Weapon")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(5);
            Destroy(hitRate.gameObject);
            Destroy(this.gameObject);
        }


    }

}
