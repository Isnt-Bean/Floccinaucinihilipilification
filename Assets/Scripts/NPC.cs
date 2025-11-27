using UnityEngine;
using System;
using System.Collections;

public class NPC : MonoBehaviour
{
    public event Action EnteredSpace;
    public event Action DialogEmpty;
    public Observer o;
    public String[] newText;

    public String talkedToMessage;

    public Player p;
    //public TextAsset dialog;

    public int i = 0;


    public void Deincrement()
    {
        if (i > 0)
        {
            i--;
        }
    }

    public void Increment()
    {
        if (i < newText.Length - 1)
        {
            i++;
        }
    }
    
    private void Start()
    {
        //string dialogInfo = dialog.text;
        //newText = dialog.text;
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

    void Update()
    {
        if (i == newText.Length - 1)
        {
            p.StartCoroutine(p.Wait());
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            o.npcText = newText[i];
            //print("Player Entered");
            TalkToPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("Player Exited");
            talkedToMessage = "Why are you still talking to me?";
            BlankText();
        }
    }
    
}