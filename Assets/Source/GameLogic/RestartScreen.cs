using UnityEngine;
using UnityEngine.SceneManagement;

namespace SDAZDGAMEpol5.GameLogic
{
    public class RestartScreen : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Restart level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }   
    }
}