namespace PreparingForJamProject.Abstracts.Inputs
{
    public interface IMyInput
    {
        float Horizontal { get; }
        bool IsJumpButtonDown { get; }
        bool IsInteractButtonDown { get; }
    }
}