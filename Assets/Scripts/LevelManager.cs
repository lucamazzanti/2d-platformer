using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int respawnTime;
    public int collectedGems;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCoroutine());
    }

    IEnumerator RespawnPlayerCoroutine()
    {
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnTime);

        PlayerController.instance.gameObject.transform.position = CheckpointController.instance.spawnPoint;

        PlayerController.instance.StopKnockback();

        PlayerController.instance.gameObject.SetActive(true);

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;

        UIController.instance.UpdateHealth(PlayerHealthController.instance.currentHealth);
    }

    public void PickupGem()
    {
        collectedGems++;

        UIController.instance.UpdateGems(collectedGems);
    }
}
