using UnityEngine;
using System;

public class NPC : MonoBehaviour
{
    public event Action EnteredSpace;
    public event Action DialogEmpty;
    public Observer o;
    public String newText;
    public TextAsset dialog;

    
    private void Start()
    {
        string dialogInfo = dialog.text;
        newText = dialog.text;
        BlankText();
    }
    private void TalkToPlayer()
    {
        EnteredSpace?.Invoke();
    }

    private void BlankText()
    {
        DialogEmpty?.Invoke();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("Player Entered");
            o.npcText = newText;
            TalkToPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("Player Exited");
            newText = "Why are you still talking to me?";
            BlankText();
        }
    }
}