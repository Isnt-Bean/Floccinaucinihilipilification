using UnityEngine;

public class ReadDialog : MonoBehaviour
{

    public TextAsset dialog;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string dialogInfo = dialog.text;
        
        print(dialogInfo);
        //use command to be able to activate dialog and undo dialog progession
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
