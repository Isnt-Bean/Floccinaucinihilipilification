using UnityEngine;
using System.Collections;
using TMPro;

public class Observer : MonoBehaviour
{
    public NPC npc;
    public TextMeshProUGUI text;
    public string npcText;

    void Update()
    {
        npcText = npc.newText[npc.i];
        
        OnNPCSpeak();
    }
    
    //these need to be in command
    public void Deincrement()
    {
        ICommand storedCommand = new Commands(npc);
        storedCommand.Undo();
    }

    public void Increment()
    {        
        ICommand storedCommand = new Commands(npc);
        storedCommand.Execute();
  
    }
    private void OnNPCSpeak()
    {
        text.text = npcText;
    }

    private void OnBlankDialog()
    {
        text.text = "";
    }

    private void Awake()
    { 
        if (npc != null) 
        {
            npc.EnteredSpace += OnNPCSpeak;
            
        } 
        if (npc != null) 
        {
            npc.DialogEmpty += OnBlankDialog;
        }
    }
}