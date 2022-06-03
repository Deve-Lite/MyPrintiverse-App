
namespace MyPrintiverse.FilamentsModule.Spools.EditSpoolPage
{
    public class EditSpoolViewModel : EditItemViewModel<Spool>
    {
        public EditSpoolViewModel(SpoolService spoolService)
        {
            ItemService = spoolService;
        }
    }
}
