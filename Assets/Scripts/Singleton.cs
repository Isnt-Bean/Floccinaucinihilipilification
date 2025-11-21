using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    public CameraFade cf;
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
        var temp = cf.fade.GetComponent<Image>().color;
        if (temp.a >= 1.99f && isTP == false)
        {
            StartCoroutine(wait());
            isTP = true;
            print("Player Teleports");
        }
        //get the camera fade script, detect when the screen fades to black, then move the player before the fade goes away
        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.5f);
        isTP = false;
    }
}
