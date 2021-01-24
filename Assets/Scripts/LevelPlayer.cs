using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlayer : MonoBehaviour
{
    public LevelController levelController;

    public int moveSpeed;

    public MapPoint currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(gameObject.transform.position, currentPoint.transform.position) < .1f)
        {
            if (Input.GetAxisRaw("Vertical") > .5f && currentPoint.up != null)
            {
                currentPoint = currentPoint.up;
            }
            else if (Input.GetAxisRaw("Vertical") < -.5f && currentPoint.down != null)
            {
                currentPoint = currentPoint.down;
            }
            else if (Input.GetAxisRaw("Horizontal") > .5f && currentPoint.right != null)
            {
                currentPoint = currentPoint.right;
            }
            else if (Input.GetAxisRaw("Horizontal") < -.5f && currentPoint.left != null)
            {
                currentPoint = currentPoint.left;
            }

            if (levelController != null && currentPoint.isLevel && !string.IsNullOrEmpty(currentPoint.levelName) 
                && Input.GetKeyDown(KeyCode.Space))
            {
                levelController.LoadScene(currentPoint.levelName);
            }
        }
    }
}
