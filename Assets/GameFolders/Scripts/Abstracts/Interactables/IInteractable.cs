namespace PreparingForJamProject.Abstracts.Interactables
{
    public interface IInteractable
    {
        void Interact();
        bool IsTriggered { get; }
        bool IsInteracted { get; set; }
    }
}