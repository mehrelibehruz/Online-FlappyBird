using UnityEngine;

namespace Assets.Scripts.Game
{
    public class StringHelper
    {
        public static bool print;
        public static void Log(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                Debug.Log("This is empty");
            }
            else if (print)
            {
                Debug.Log(message);
            }
        }
        public static void Log(string message, bool isActive)
        {
            Debug.Log(message);
        }
    }
    enum Scene
    {
        MainMenu,
        ScoreScene,
        Game
    }
}
