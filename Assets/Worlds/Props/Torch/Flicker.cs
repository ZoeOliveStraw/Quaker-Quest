using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    [SerializeField] Vector2 minMaxFlickerLength;
    [SerializeField] Vector2 minMaxFlickerIntensity;
    private Light myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        StartCoroutine(FlickerMe());
    }

    private IEnumerator FlickerMe()
    {
        myLight.intensity = Random.Range(minMaxFlickerIntensity.x, minMaxFlickerIntensity.y);
        yield return new WaitForSeconds(Random.Range(minMaxFlickerLength.x,minMaxFlickerLength.y));
        StartCoroutine(FlickerMe());
    }
}
