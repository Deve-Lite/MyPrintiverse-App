
namespace MyPrintiverse.FilamentsModule.Spools.AddSpoolPage
{
    public class AddSpoolViewModel : AddItemViewModel<Spool>
    {
        public AddSpoolViewModel(SpoolService spoolService)
        {
            ItemService = spoolService;
        }
    }
}
