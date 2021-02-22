using UnityEngine;
using UnityEngine.SceneManagement;

namespace PreparingForJamProject.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            SingletonObject();
        }
        public void StartGame(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
        public void LoadGameScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
        public void CreditsToMenu(GameObject mainScreen, GameObject creditsScreen)
        {
            mainScreen.SetActive(true);
            creditsScreen.SetActive(false);
        }
        public void Credits(GameObject mainScreen, GameObject creditsScreen)
        {
            mainScreen.SetActive(false);
            creditsScreen.SetActive(true);
        }
        public void Quit()
        {
            Application.Quit();
        }
        void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else Destroy(this.gameObject);
        }
    }
}