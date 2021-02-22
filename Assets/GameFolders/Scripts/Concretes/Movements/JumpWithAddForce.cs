using PreparingForJamProject.Abstracts.Controllers;
using PreparingForJamProject.Abstracts.Movements;
using PreparingForJamProject.Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PreparingForJamProject.Concretes.Movements
{
    public class JumpWithAddForce : IJump
    {
        private IEntityController _controller;
        private bool _isJump = false;
        private float _jumpSpeed = default;
        public bool IsJump { get => _isJump; set => _isJump = value; }
        
        public JumpWithAddForce(IEntityController controller, float jumpSpeed)
        {
            _controller = controller;
            _jumpSpeed = jumpSpeed;
        }

        public void JumpAction()
        {
            if (_controller != null)
                _controller.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpSpeed);
        }
    }
}