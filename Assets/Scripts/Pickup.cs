using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private bool pickup;
    public bool isGem;
    public bool isHeal;

    public GameObject pickupAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !pickup)
        {
            pickup = true;

            if (isGem)
            {
                LevelManager.instance.PickupGem();
                Instantiate(pickupAnimation, transform.position, transform.rotation);
                AudioManager.instance.PlaySoundEffect("Pickup Gem");
            }

            if (isHeal)
            {
                PlayerHealthController.instance.Heal();
                AudioManager.instance.PlaySoundEffect("Pickup Health");
            }
            
            Destroy(gameObject);
        }
    }
}
