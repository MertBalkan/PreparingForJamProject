namespace PreparingForJamProject.Abstracts.Animations
{
    public interface IMyAnimation
    {
        void WalkAnimationAction(float hor);
        void JumpAnimationAction(bool isJump);
        void InteractAnimationAction();
        bool IsInteracted { get; set; }

    }
}