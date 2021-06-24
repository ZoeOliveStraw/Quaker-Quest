using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] Image panel;
    [SerializeField] float fadeDuration;

    private void Start() 
    {
           
    }
    
    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }
    private IEnumerator FadeInCoroutine()
    {
        float currentAlpha = 1.0f;
        SetAlpha(currentAlpha);
        for(float i = fadeDuration; i >= 0; i -= 0.05f)
        {
            currentAlpha = i / fadeDuration;
            yield return new WaitForSeconds(0.05f);
            SetAlpha(currentAlpha);
        }
        Debug.Log("Done!");
        currentAlpha = 0.0f;
        SetAlpha(currentAlpha);
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }
    private IEnumerator FadeOutCoroutine()
    {
        Debug.Log("Fade Out called!");
        float currentAlpha = 0.0f;
        SetAlpha(currentAlpha);
        for(float i = 0; i <= fadeDuration; i += 0.05f)
        {
            currentAlpha = i / fadeDuration;
            yield return new WaitForSeconds(0.05f);
            SetAlpha(currentAlpha);
        }
        currentAlpha = 1.0f;
        SetAlpha(currentAlpha);
    }

    public float GetFadeDuration()
    {
        return fadeDuration;
    }
    private void SetAlpha(float a) 
    {
        panel.color = new Color(panel.color.r,panel.color.g,panel.color.b,a);
    }
}
