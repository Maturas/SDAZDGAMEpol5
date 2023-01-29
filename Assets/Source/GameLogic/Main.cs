using UnityEngine;
using UnityEngine.SceneManagement;

namespace SDAZDGAMEpol5.GameLogic
{
    public class Main : MonoBehaviour
    {
        [field: SerializeField]
        private int LevelToLoadIndex { get; set; }
        
        private void Start()
        {
            SceneManager.LoadScene(LevelToLoadIndex);
        }
    }
}