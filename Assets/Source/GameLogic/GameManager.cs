using UnityEngine;

namespace SDAZDGAMEpol5.GameLogic
{
    /// <summary>
    ///     This class implements Singleton design pattern - single, globally available instance, which is created
    ///     at the start of the program and destroyed at the end. USE WITH CAUTION!
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        /// <summary>
        ///     Awake executes before Start
        /// </summary>
        private void Awake()
        {
            if (Instance)
            {
                Debug.LogError("Found another instance of GameManager! Destroying!");
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}