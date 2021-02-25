using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, down, left, right;
    public bool isLevel, isLocked;
    public string levelName, previousLevelName;

    // Start is called before the first frame update
    void Start()
    {
        if (isLevel && !string.IsNullOrEmpty(levelName) && !string.IsNullOrEmpty(previousLevelName))
        {
            isLocked = true;

            if (PlayerPrefs.HasKey(previousLevelName + "_unlocked"))
            {
                if (PlayerPrefs.GetInt(previousLevelName + "_unlocked") == 1)
                {
                    isLocked = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
