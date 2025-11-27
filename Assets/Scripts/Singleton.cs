using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    public CameraFade cf;
    public GameObject fade;
    public bool isTP = false;
    void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        var temp = fade.GetComponent<Image>().color;
        if (temp.a >= 1.99f && isTP == false)
        {
            StartCoroutine(wait());
            isTP = true;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.5f);
        isTP = false;
    }
}
