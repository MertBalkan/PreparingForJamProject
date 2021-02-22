using PreparingForJamProject.Abstracts.Animations;
using PreparingForJamProject.Abstracts.Controllers;
using PreparingForJamProject.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PreparingForJamProject.Concretes.Controllers
{
    public class CameraController : MonoBehaviour, ICameraShake
    {
        [Header("------CameraLook------")]
        [SerializeField] private float smoothCameraLook = default;

        [Header("------CameraShake------")]
        [SerializeField] private float slowCameraShake = default;
        [SerializeField] private float startDuration = default;


        private IEntityController _playerTransform;

        private bool _isCameraShake = false;
        private float _duration = default;

        public bool IsCameraShake { get => _isCameraShake; set => _isCameraShake = value; }

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>();
        }
        private void Update()
        {
            if (_playerTransform == null) return;
            SetCameraLook();
        }
        private void SetCameraLook()
        {
            Vector3 playerVec = new Vector3(_playerTransform.transform.position.x, _playerTransform.transform.position.y + 2, -10);
            Vector3 smoothVec = Vector3.Lerp(transform.position, playerVec, smoothCameraLook);
            transform.rotation = _playerTransform.transform.rotation;
            transform.position = smoothVec;
        }
        public void ShakeCamera()
        {
            if (IsCameraShake)
            {
                if (_duration > 0)
                {
                    transform.localPosition = transform.localPosition + Random.insideUnitSphere * 0.7f;
                    _duration -= Time.deltaTime * slowCameraShake;
                }
                else
                {
                    IsCameraShake = false;
                    _duration = startDuration;
                    transform.localPosition = transform.localPosition;
                }
            }
        }
    }
}