namespace PreparingForJamProject.Abstracts.Movements
{

    public interface ICameraShake
    {
        bool IsCameraShake { get; set; }
        void ShakeCamera();
    }
}