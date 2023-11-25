using UnityEngine;

public class First : MonoBehaviour
{
    public static First INSTANCE;

    private void Awake()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(INSTANCE);
        }
        DontDestroyOnLoad(gameObject);
    }
}
