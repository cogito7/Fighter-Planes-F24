using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private float speed = 3f; // Base speed of the enemy
    private float zigzagFrequency = 2f; // Frequency of the zigzag movement
    private float zigzagMagnitude = 1f; // Amplitude of the zigzag

    // Start is called before the first frame update
    void Start()
    {
        // You can add initialization logic here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Zigzag movement pattern
        float xMovement = Mathf.Sin(Time.time * zigzagFrequency) * zigzagMagnitude;
        float yMovement = -1 * Time.deltaTime * speed; // Move down the screen

        transform.Translate(new Vector3(xMovement, yMovement, 0));

        // Destroy the enemy when it goes off-screen
        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }
}
