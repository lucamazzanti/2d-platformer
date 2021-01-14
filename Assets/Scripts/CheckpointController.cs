using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;

    private Checkpoint[] checkpoints;

    public Vector3 spawnPoint;

    void Awake()
    {
        instance = this;

        //spawnPoint = PlayerController.instance.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetAllCheckpoints()
    {
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.ResetCheckpoint();
        }
    }

    public void SetSpawnPoint(Vector3 spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }
}
