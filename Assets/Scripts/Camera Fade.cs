using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CameraFade : MonoBehaviour
{
    public bool StartFade = false;
    public GameObject fade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        StartFade = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartFade)
        {
            StartCoroutine(FadeIn());
            //up the alpha value

            //teleport the player to a new area

            //lower the alpha value then delete using singleton
        }
    }

    IEnumerator FadeIn()
    {
        var temp = fade.GetComponent<Image>().color;//fade in
        temp.a += 0.01f;
        fade.GetComponent<Image>().color = temp;
        
        
        yield return new WaitForSeconds(2f);
        
        
        var temp2 = fade.GetComponent<Image>().color;//fade out
        temp2.a -= 0.01f;
        fade.GetComponent<Image>().color = temp2;
        StartFade = false;
        StopCoroutine(FadeIn());
    }
}
