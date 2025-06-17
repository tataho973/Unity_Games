using UnityEngine;
using UnityEngine.SceneManagement;

namespace Taho
{
    public class Menu : MonoBehaviour
    {
        public GameObject settings;

        private void Awake()
        {
            settings.SetActive(false);
        }

        public void Play()
        {
            SceneManager.LoadScene(1);
        }
        
        public void Settings()
        {
            settings.SetActive(!settings.activeSelf);
        }
    }
}