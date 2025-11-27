using Unity.VisualScripting;
using UnityEngine;

public class DirtyFlagCheck : MonoBehaviour
{
//https://learn.unity.com/tutorial/dirty-flag-pattern
    public float m_LoadRadius = 50f;

    public bool IsLoaded { get; private set; } = false;
    public bool IsDirty { get; private set; } = false;
            
    void Awake()
    {
        Clean();
        IsLoaded = false;
    }
    
    public void MarkDirty()
    {
        IsDirty = true;
    }
    
    public void LoadContent()
    {
        IsLoaded = true;
        this.GameObject().SetActive(true);
    }
    
    public void UnloadContent()
    {
        IsLoaded = false;
        this.GameObject().SetActive(false);
    }
    
    public bool IsPlayerClose(Vector3 playerPosition)
    {
        return Vector3.Distance(playerPosition, transform.position) <= m_LoadRadius;
    }
    
    public void Clean()
    {
        IsDirty = false;
    }
}
