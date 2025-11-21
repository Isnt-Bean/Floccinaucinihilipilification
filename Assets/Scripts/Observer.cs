using UnityEngine;
using System.Collections;
using TMPro;

public class Observer : MonoBehaviour
{
    public NPC npc;
    public TextMeshProUGUI text;
    public string npcText;

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