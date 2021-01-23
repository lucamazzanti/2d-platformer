using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int respawnTime;
    public int collectedGems;
    public string nextSceneName;

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

        //AudioManager.instance.PlaySoundEffect("Player Death");

        yield return new WaitForSeconds(respawnTime - (1f / UIController.instance.fadeSpeed));

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .2f);

        UIController.instance.FadeFromBlack();

        AudioManager.instance.PlaySoundEffect("Map Movement");

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

    public void EndLevel()
    {
        StartCoroutine(EndLevelCoroutine());
    }

    private IEnumerator EndLevelCoroutine()
    {
        PlayerController.instance.blockInput = true;

        CameraController.instance.stopfollowTarget = true;

        UIController.instance.endLevelText.gameObject.SetActive(true);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .2f);

        SceneManager.LoadScene(nextSceneName);
    }
}
