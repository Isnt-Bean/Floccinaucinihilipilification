using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject TextDialogBox;
    public GameObject DialogPrompt;
    public bool istalking = false;
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
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DialogPrompt.SetActive(false);
            istalking = true;
            TextDialogBox.SetActive(true);
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
}
