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

    bool OneFingerTap;
    float TimerOne;
    float timerInterval = 0.1f; //the more you decrease it the more accurate it gets 
    private void Update()
    {
        if (OneFingerTap && (TimerOne + timerInterval <= Time.time))
        {
            OneFingerTap = false;
        }
        //if there are any touches currently
        if (Input.touchCount > 0)
        {
            // get the first one
            Touch firstTouch = Input.GetTouch(0);

            //two touches detected
            if (Input.touchCount == 2)
            {
                Touch secondTouch = Input.GetTouch(1);
                if (firstTouch.phase == TouchPhase.Began || secondTouch.phase == TouchPhase.Began)
                {
                    OneFingerTap = false;
                }
            }
            //if Only one touch detected
            else if(firstTouch.phase == TouchPhase.Began)
            {
                TimerOne = Time.time;
                OneFingerTap = true;
            }

        }

    }


}

//public string GetAppVersion()
//{
//    return AppVersion = "Version: " + Application.version;
//}

