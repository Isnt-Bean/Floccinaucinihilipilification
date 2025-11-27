using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CameraFade : MonoBehaviour
{
    public bool StartFadeIn = false;
    public bool StartFadeOut = false;
    public GameObject fade;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        StartFadeOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartFadeIn)
        {
            StartCoroutine(FadeIn());
            //have fade turn on when walking into a new area
        }

        if (StartFadeOut)
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        var temp = fade.GetComponent<Image>().color;//fade in
        temp.a += 0.01f;
        fade.GetComponent<Image>().color = temp;
        
        
        yield return new WaitForSeconds(1f);
        StopCoroutine(FadeIn());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1f);
        
        var temp2 = fade.GetComponent<Image>().color;//fade out
        temp2.a -= 0.01f;
        fade.GetComponent<Image>().color = temp2;
        StartFadeOut = false;
        StopCoroutine(FadeOut());
    }
}
