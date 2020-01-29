namespace SystemePAC.Help
{
    public interface INavigationService
    {
        void GoForward();
        void GoBack();
        bool Navigate(string page);
    }
}
