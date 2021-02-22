using PreparingForJamProject.Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PreparingForJamProject.Concretes.Inputs
{
    public class PcInput : IMyInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");

        public bool IsJumpButtonDown => Input.GetKeyDown(KeyCode.Space);

        public bool IsInteractButtonDown => Input.GetKeyDown(KeyCode.F);
    }
}