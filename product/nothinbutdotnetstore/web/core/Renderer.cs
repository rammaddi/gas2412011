namespace nothinbutdotnetstore.web.core
{
    public interface Renderer
    {
        void display<DisplayModel>(DisplayModel item);
    }
}