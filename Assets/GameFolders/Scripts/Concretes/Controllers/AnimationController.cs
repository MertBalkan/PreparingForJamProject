using PreparingForJamProject.Abstracts.Animations;
using PreparingForJamProject.Abstracts.Controllers;
using PreparingForJamProject.Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : IMyAnimation
{
    private IEntityController _controller;
    private bool _isInteracted = false;

    public bool IsInteracted { get => _isInteracted; set => _isInteracted = value; }

    public AnimationController(IEntityController controller)
    {
        _controller = controller;
    }

    public void JumpAnimationAction(bool isJump)
    {
        if (_controller.transform.GetComponent<Animator>().GetBool("isJump") == isJump) return;

        _controller.transform.GetComponent<Animator>().SetBool("isJump", isJump);
    }

    public void WalkAnimationAction(float hor)
    {
        if (hor < 0) hor = 1;
        _controller.transform.GetComponent<Animator>().SetFloat("speed", hor);
    }
    public void InteractAnimationAction()
    {
        if (_isInteracted)
        {
            _controller.transform.GetComponent<Animator>().SetTrigger("interact");
            _isInteracted = false;
        }
    }
}