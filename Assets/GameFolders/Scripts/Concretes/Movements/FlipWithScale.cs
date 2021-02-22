using PreparingForJamProject.Abstracts.Controllers;
using PreparingForJamProject.Concretes.Controllers;
using UnityEngine;

namespace PreparingForJamProject.Concretes.Movements
{
    public class FlipWithScale : IFlip
    {
        private IEntityController _controller;
        private float _flipValue;

        public FlipWithScale(IEntityController controller, float flipValue)
        {
            _controller = controller;
            _flipValue = flipValue;
        }
        public void FlipAction(float hor)
        {
            if (hor == 0) return;
            hor = Mathf.Sign(hor);

            if (hor == -1) _controller.transform.localScale = new Vector2((hor + _flipValue), _controller.transform.localScale.y);
            if (hor == 1) _controller.transform.localScale = new Vector2((hor - _flipValue), _controller.transform.localScale.y);
        }
    }
}