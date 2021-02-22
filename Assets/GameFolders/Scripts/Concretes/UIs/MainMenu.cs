using PreparingForJamProject.Concretes.Managers;
using UnityEngine;
namespace PreparingForJamProject.Concretes.UIs
{
    public class MainMenu : MonoBehaviour
    {
        [Header("UIPages")]
        [SerializeField] private GameObject mainScreen;
        [SerializeField] private GameObject creditsScreen;

        public void StartGame()
        {
            GameManager.Instance.StartGame(1);
        }
        public void CreToMenu()
        {
            GameManager.Instance.CreditsToMenu(mainScreen, creditsScreen);
        }
        public void Credits()
        {
            GameManager.Instance.Credits(mainScreen, creditsScreen);
        }
        public void Exit()
        {
            GameManager.Instance.Quit();
        }
    }
}