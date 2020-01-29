namespace NancyWebApi
{
    public class MainModule: Nancy.NancyModule
    {
        public MainModule()
        {
            Get["/"] = _ => "Received GET request";

            Post["/"] = _ => "Received POST request";
        }
    }
}
