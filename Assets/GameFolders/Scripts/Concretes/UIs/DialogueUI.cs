using UnityEngine;
using UnityEngine.UI;

namespace PreparingForJamProject.Concretes.UIs
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private Text dialogueText;

        public void SendMessage(string message)
        {
            dialogueText.text = message;
        }
        public void SetActiveToDialogueUI(bool isActive)
        {
            this.gameObject.SetActive(isActive);
        }
    }
}