using PreparingForJamProject.Abstracts.Controllers;
using PreparingForJamProject.Abstracts.Movements;
using PreparingForJamProject.Concretes.Controllers;
using UnityEngine;

namespace PreparingForJamProject.Concretes.Movements
{
    public class MoveWithTransform : IMover
    {
        private IEntityController _controller;
        private float _speed;

        public MoveWithTransform(IEntityController controller, float speed)
        {
            _controller = controller;
            _speed = speed;
        }
        public void Move(float hor)
        {
            _controller.transform.Translate(Vector2.right * _speed * Time.deltaTime * hor);
        }
    }
}