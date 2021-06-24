using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Fade _fade;
    // Start is called before the first frame update
    void Start()
    {
        _fade = GetComponent<Fade>();
        _fade.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(FadeBetweenScenes(sceneIndex));
    }

    private IEnumerator FadeBetweenScenes(int mySceneIndex)
    {
        float fadeLength = _fade.GetFadeDuration();
        _fade.FadeOut();
        yield return new WaitForSeconds(fadeLength);
        SceneManager.LoadScene(mySceneIndex);
        _fade.FadeIn();
        yield return new WaitForSeconds(fadeLength);
    }
}
