using TMPro;
using UnityEngine;
using System.Collections;

public class ReadDialog : MonoBehaviour
{
//THIS SCRIPT WILL BE TURNED INTO A COMMAND FUNCTION IN THE FUTURE, FOR NOW IT'S TO DEMONSTRATE THE FUNCTIONS OF THE GAME//
    public TextAsset dialog;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string dialogInfo = dialog.text;
        text.text = dialogInfo;
        //print(dialogInfo);
        //use command to be able to activate dialog and undo dialog progession
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
