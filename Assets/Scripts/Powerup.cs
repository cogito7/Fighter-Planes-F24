using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //makes enemy 3 travel left across the screen
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 6f);

        //destroys enemy 3 when it exits the left boundary
        if (transform.position.x < -11.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
