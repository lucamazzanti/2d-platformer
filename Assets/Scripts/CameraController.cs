using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform background;
    public Transform middleground;
    public float lastXPosition;
    public float lastYPosition;
    public float minHeigth;
    public float maxHeigth;

    // Start is called before the first frame update
    void Start()
    {
        lastXPosition = transform.position.x;
        lastYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y,minHeigth,maxHeigth), transform.position.z);

        //parallax
        float xDiff = transform.position.x - lastXPosition;
        float yDiff = transform.position.y - lastYPosition;

        background.position += new Vector3(xDiff, yDiff, 0f);
        middleground.position += new Vector3(xDiff * 0.5f, yDiff * 0.5f, 0f);

        lastXPosition = transform.position.x;
        lastYPosition = transform.position.y;
    }
}
