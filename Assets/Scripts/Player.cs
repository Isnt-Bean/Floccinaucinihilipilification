using System;
using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    public GameObject TextDialogBox;
    public GameObject DialogPrompt;
    public bool isTalking = false;
    private float speed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextDialogBox.SetActive(false);
        DialogPrompt.SetActive(false);
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
        
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            speed = 0f;
            DialogPrompt.SetActive(false);
            isTalking = true;
            TextDialogBox.SetActive(true);
            StartCoroutine(Wait());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            DialogPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DialogPrompt.SetActive(false);
    }
    
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        isTalking = false;
        TextDialogBox.SetActive(false);
        speed = 5f;
    }
}
