using UnityEngine;

public class DirtyFlag : MonoBehaviour
{
    //https://learn.unity.com/tutorial/dirty-flag-pattern
    public Player player;
    public DirtyFlagCheck[] check;

    private void Update()
    {
        foreach (DirtyFlagCheck checkIfDirty in check)
        {
            bool isPlayerClose = checkIfDirty.IsPlayerClose(player.transform.position);

            if (isPlayerClose != checkIfDirty.IsLoaded)
            {
                checkIfDirty.MarkDirty();
            }
            
            if (checkIfDirty.IsDirty)
            {
                if (isPlayerClose)
                {
                    checkIfDirty.LoadContent();
                }
                else
                {
                    checkIfDirty.UnloadContent();
                }
                
                checkIfDirty.Clean();
            }
        }
    }
}
