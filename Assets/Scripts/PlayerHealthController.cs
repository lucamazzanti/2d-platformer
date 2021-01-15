using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth;
    public int maxHealth;

    public float invincibleLength;
    public float invincibleCounter;

    private SpriteRenderer spriteRenderer;
    public GameObject deathEffect;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter >= 0)
        {
            invincibleCounter -= Time.deltaTime;
        }

        if (invincibleCounter <= 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        }
    }

    public void TakeDamage()
    {
        if (invincibleCounter <= 0)
        {
            currentHealth--;
            invincibleCounter = invincibleLength;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, .5f);

            if (currentHealth == 0)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);

                AudioManager.instance.PlaySoundEffect("Player Death");

                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                AudioManager.instance.PlaySoundEffect("Player Hurt");
            }

            UIController.instance.UpdateHealth(currentHealth);
        }
    }

    public void Heal()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;

            UIController.instance.UpdateHealth(currentHealth);
        }
    }
}
