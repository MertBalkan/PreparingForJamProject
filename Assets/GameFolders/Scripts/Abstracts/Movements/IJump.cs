namespace PreparingForJamProject.Abstracts.Movements
{
    public interface IJump
    {
        bool IsJump { get; set; }
        void JumpAction();
    }
}