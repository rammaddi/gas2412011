namespace nothinbutdotnetstore.web.core
{
    public delegate ViewDataType ViewDataTypeRepository<ViewDataType>(Request request);
    public class CatalogCommand<ViewDataType> : ApplicationCommand
    {
        ViewDataTypeRepository<ViewDataType> repository;
        Renderer renderer;



        public CatalogCommand(ViewDataTypeRepository<ViewDataType> repository, Renderer renderer)
        {
            this.repository = repository;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
            renderer.display(repository(request));
        }
    }
}