using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        LevelUIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1 / LevelUIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(sceneName);
    }
}
