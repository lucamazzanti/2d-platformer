using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    public Vector2 minPos, maxPos;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // evento successivo agli Update perchè non sai in che ordine sono eseguiti, potrebbe accadere prima di Player
    void LateUpdate()
    {
        float x = Mathf.Clamp(target.position.x, minPos.x, maxPos.x);
        float y = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);
        transform.position = new Vector3(x,y, transform.position.z);
    }
}
