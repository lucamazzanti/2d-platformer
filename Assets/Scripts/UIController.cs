using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image hearth1, hearth2, hearth3;

    public Text gemText;

    public Sprite fullHearth, halfHearth, emptyHearth;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGems(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGems(int gems)
    {
        gemText.text = gems.ToString();
    }

    public void UpdateHealth(int health)
    {
        switch (health)
        {
            case 0:
                hearth1.sprite = emptyHearth;
                hearth2.sprite = emptyHearth;
                hearth3.sprite = emptyHearth;
                break;
            case 1:
                hearth1.sprite = halfHearth;
                hearth2.sprite = emptyHearth;
                hearth3.sprite = emptyHearth;
                break;
            case 2:
                hearth1.sprite = fullHearth;
                hearth2.sprite = emptyHearth;
                hearth3.sprite = emptyHearth;
                break;
            case 3:
                hearth1.sprite = fullHearth;
                hearth2.sprite = halfHearth;
                hearth3.sprite = emptyHearth;
                break;
            case 4:
                hearth1.sprite = fullHearth;
                hearth2.sprite = fullHearth;
                hearth3.sprite = emptyHearth;
                break;
            case 5:
                hearth1.sprite = fullHearth;
                hearth2.sprite = fullHearth;
                hearth3.sprite = halfHearth;
                break;
            case 6:
                hearth1.sprite = fullHearth;
                hearth2.sprite = fullHearth;
                hearth3.sprite = fullHearth;
                break;
        }
    }
}
