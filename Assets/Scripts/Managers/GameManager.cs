using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public string AppVersion { get; private set; }

    public static GameManager instance;
    public int Score { get; set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        AppVersion = "Version: " + Application.version;
    }


    //public string GetAppVersion()
    //{
    //    return AppVersion = "Version: " + Application.version;
    //}
}
