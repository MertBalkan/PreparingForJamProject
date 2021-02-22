using PreparingForJamProject.Abstracts.Animations;
using PreparingForJamProject.Abstracts.Controllers;
using PreparingForJamProject.Abstracts.Inputs;
using PreparingForJamProject.Abstracts.Interactables;
using PreparingForJamProject.Abstracts.Movements;
using PreparingForJamProject.Concretes.Inputs;
using PreparingForJamProject.Concretes.Interactables;
using PreparingForJamProject.Concretes.Movements;
using PreparingForJamProject.Concretes.Observers;
using PreparingForJamProject.Concretes.UIs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PreparingForJamProject.Concretes.Controllers
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(BoxCollider2D))]
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float speed = default;
        [SerializeField] private float jumpSpeed = default;
        [SerializeField] private CameraController camera;

        [Header("Audios")]
        [SerializeField] private AudioClip jumpClip;
        [SerializeField] private AudioClip interactSoundClip;
        [SerializeField] private AudioClip[] walkClips;

        private float _itemTakeTime = 1.3f;
        private bool _canMove = true;

        private AudioObserver _audioObserver;
        private DialogueUI _dialogueUI;

        private IMyInput _input;
        private IFlip _flip;
        private IMover _mover;
        private IMyAnimation _animation;
        private IJump _jump;
        private IOnGround _onGround;
        private IInteractable _interact;

        private void Awake()
        {
            _jump = new JumpWithAddForce(this, jumpSpeed);
            _mover = new MoveWithTransform(this, speed);
            _input = new PcInput();
            _flip = new FlipWithScale(this, 0.4f);
            _animation = new AnimationController(this);

            _interact = FindObjectOfType<InteractMouse>().GetComponent<IInteractable>();
            _onGround = GetComponent<OnGround>();
            camera = FindObjectOfType<CameraController>();
            _audioObserver = FindObjectOfType<AudioObserver>();
            _dialogueUI = FindObjectOfType<DialogueUI>();
        }
        private void Update()
        {
            float hor = _input.Horizontal;
            int randomWalkSoundIndex = Random.Range(0, walkClips.Length);

            Debug.Log(_canMove);

            if (_interact.IsInteracted)
            {
                _itemTakeTime -= Time.deltaTime;
                _canMove = false;
                _audioObserver.MuteAllSounds();
            }
            if (_itemTakeTime <= 0) 
            {
                _itemTakeTime = 0;
                _canMove = true;
                _audioObserver.ReMuteAllSounds();
            }

            if (_input.IsJumpButtonDown && _onGround.IsOnGround && _canMove)
            {
                _audioObserver.IsSoundPlaying = true;
                _audioObserver.PlayOneShot(jumpClip);
                _jump.IsJump = true;
                _animation.JumpAnimationAction(true);
                _onGround.IsOnGround = false;
                _animation.JumpAnimationAction(_jump.IsJump);
            }

            if (_input.IsInteractButtonDown) _animation.IsInteracted = true;

            if (_input.IsInteractButtonDown && _interact.IsTriggered)
            {
                _interact.Interact();
                _animation.InteractAnimationAction();
                _audioObserver.PlayOneShot(interactSoundClip);
            }

            if (_onGround.IsOnGround) _animation.JumpAnimationAction(false);
            if (!_onGround.IsOnGround) _animation.JumpAnimationAction(true);

            if (_input.IsInteractButtonDown)
            {
                camera.IsCameraShake = true;
                camera.ShakeCamera();
            }

            //Sound Managment
            if (_audioObserver.AudioTimer == _audioObserver.CurrentAudioTime && hor != 0)
            {
                _audioObserver.PlayOneShot(walkClips[randomWalkSoundIndex]);
                _audioObserver.CurrentAudioTime = 0.0f;
                _audioObserver.IsSoundPlaying = true;
            }
            if (!_onGround.IsOnGround && hor != 0)
                _audioObserver.IsSoundPlaying = false;

            //Action managment

            if (_canMove)
            {
                _animation.WalkAnimationAction(hor);
                _mover.Move(hor);
                _flip.FlipAction(hor);
            }

        }
        private void FixedUpdate()
        {
            //Jumping
            if (_jump.IsJump && _onGround.IsOnGround && _canMove)
            {
                camera.IsCameraShake = true;
                camera.ShakeCamera();
                _animation.JumpAnimationAction(_jump.IsJump);
                _jump.IsJump = false;
                _jump.JumpAction();
            }
        }
    }
}