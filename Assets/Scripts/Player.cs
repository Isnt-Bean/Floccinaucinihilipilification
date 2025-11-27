using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public CameraFade cF;
    public GameObject TextDialogBox;
    public GameObject DialogPrompt;
    public GameObject TeleportPrompt;
    public Observer o;
    public NPC npc;
    private bool isTalking = false;
    private bool canTalk = false;
    private bool canTP = false;
    private float speed = 5f;
    private string tpText;
    
    void Start()
    {
        TextDialogBox.SetActive(false);
        DialogPrompt.SetActive(false);
        TeleportPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        // Movement direction
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        // Apply movement
        transform.Translate(direction * speed * Time.deltaTime);
        
        if (isTalking == false)
        {
            StopCoroutine(Wait());
        }

        if (canTP && Input.GetKeyDown(KeyCode.E))
        {
            TeleportPrompt.SetActive(true);
            cF.StartFadeIn = true;
            StartCoroutine(ChangeScene());
        }

        if (canTalk && Input.GetKeyDown(KeyCode.E))
        {
            speed = 0f;
            DialogPrompt.SetActive(false);
            isTalking = true;
            TextDialogBox.SetActive(true);
            //StartCoroutine(Wait());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            DialogPrompt.SetActive(true);
            canTalk = true;
        }

        if (other.gameObject.CompareTag("Teleport"))
        {
            canTP = true;
            TeleportPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DialogPrompt.SetActive(false);
        TeleportPrompt.SetActive(false);
        canTalk = false;
        canTP = false;
    }
    
    
    /*
     IDEAS: 
     - Police accident scene somewhere
     - End Game Condition is falling asleep and waking up again
     */
    
    
    
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        npc.i = 0;
        isTalking = false;
        TextDialogBox.SetActive(false);
        speed = 5f;
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
