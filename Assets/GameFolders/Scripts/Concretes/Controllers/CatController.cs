using PreparingForJamProject.Abstracts.Animations;
using PreparingForJamProject.Abstracts.Controllers;
using PreparingForJamProject.Abstracts.Movements;
using PreparingForJamProject.Concretes.Movements;
using PreparingForJamProject.Concretes.UIs;
using System.Collections;
using UnityEngine;

namespace PreparingForJamProject.Concretes.Controllers
{
    public class CatController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float speed;
        [SerializeField] private float animationWalkTime = 5f; // örnek olarak: 5 saniye yürü
        [SerializeField] private float waitTime = 3f; // örnek olarak: 3 saniye dur

        private DialogueUI _dialogue;

        private float _currentTime;
        private bool _canMove = false;
        private bool _isLookingLeft = false;

        private IFlip _flip;
        private IMover _mover;
        private IMyAnimation _animation;

        private void Awake()
        {
            _mover = new MoveWithTransform(this, speed);
            _flip = new FlipWithScale(this, 0.5f);
            _animation = new AnimationController(this);
            _dialogue = FindObjectOfType<DialogueUI>();
        }
        private void Update()
        {
            ControlCatMovements();
        }
        private void ControlCatMovements()
        {
            StartCoroutine(SetWaitTime());

            if (_currentTime >= animationWalkTime) _canMove = true;
            if (_currentTime >= animationWalkTime && _currentTime >= animationWalkTime * 2) // RANDOMIZE EDILMESI GEREKEN YER 2 katsayısı
            {
                _currentTime = 0.0f;
                _canMove = false;

                if (_currentTime <= animationWalkTime)
                {
                    SetDirectionsAndMovements(-0.5f, 0f, 0f);
                    _isLookingLeft = true;
                }
            }
            if (_isLookingLeft)
                SetDirectionsAndMovements(-0.5f, 0f, 0f);
            if (_isLookingLeft && _currentTime > 2.0f) // RANDOMIZE EDILMESI GEREKEN YER 2.0f katsayısı bu sayı animationWalkTime'den küçük ama _currentTimeden büyük olmalı
                SetDirectionsAndMovements(-0.5f, -1.0f, 1.0f);

        }
        private IEnumerator SetWaitTime()
        {
            yield return new WaitForSeconds(waitTime);

            _currentTime += Time.deltaTime;

            if (_canMove && _currentTime >= animationWalkTime)
            {
                SetDirectionsAndMovements(0.5f, .5f, 1.0f);
                _isLookingLeft = false;
            }
        }
        private void SetDirectionsAndMovements(float flip, float move, float walkAnim)
        {
            _flip.FlipAction(flip);
            _mover.Move(move);
            _animation.WalkAnimationAction(walkAnim);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _dialogue.SendMessage("MY CATT I LOVE UU");
            }
        }
    }
}