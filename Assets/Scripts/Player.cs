using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject TextDialogBox;
    private float speed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextDialogBox.SetActive(false);
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("NPC") && Input.GetKeyDown(KeyCode.E))
        {
            TextDialogBox.SetActive(true);
            //read the specific NPC's dialog
        }
    }
}
