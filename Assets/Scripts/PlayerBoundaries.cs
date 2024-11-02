using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour

{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        //takes into consideration the size of the player object
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectHeight = transform.GetComponent<MeshRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //takes in values for min and max of screen
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
        transform.position = viewPos;
    }
}