using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public Sprite checkpointOn, checkpointOff;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckpointController.instance.ResetAllCheckpoints();
            CheckpointController.instance.SetSpawnPoint(transform.position);
            _spriteRenderer.sprite = checkpointOn;
        }
    }

    public void ResetCheckpoint()
    {
        _spriteRenderer.sprite = checkpointOff;
    }
}
