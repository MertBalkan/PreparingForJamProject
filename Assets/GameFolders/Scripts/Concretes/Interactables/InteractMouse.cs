using PreparingForJamProject.Abstracts.Interactables;
using PreparingForJamProject.Concretes.UIs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PreparingForJamProject.Concretes.Interactables
{
    public class InteractMouse : MonoBehaviour, IInteractable
    {
        private bool _isTriggered = false;
        private bool _isInteracted = false;

        public bool IsTriggered => _isTriggered;

        public bool IsInteracted { get => _isInteracted; set => _isInteracted = value; }

        private DialogueUI _dialogue;

        private void Awake()
        {
            _dialogue = FindObjectOfType<DialogueUI>();
        }

        public void Interact()
        {
            _isInteracted = true;
            Destroy(gameObject, 1.30f);
        }
        private void CheckTriggers(Collider2D collision, bool isTriggered)
        {
            if (collision.gameObject.tag == "Player")
            {
                _isTriggered = isTriggered;
                Debug.Log(_isTriggered);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _dialogue.SendMessage("HELLO MY MOUSE");
            CheckTriggers(collision, true);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            _dialogue.SendMessage("SEE U MY MOUSE");
            CheckTriggers(collision, false);
        }
    }
}