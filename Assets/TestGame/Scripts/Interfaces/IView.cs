namespace TestGame.Scripts.Interfaces
{
    public delegate void ViewInitComplete(IView view);
    
    public interface IView
    {
        event ViewInitComplete OnInitComplete; 
        void AddListeners();
        void RemoveListeners();
        
    }
}