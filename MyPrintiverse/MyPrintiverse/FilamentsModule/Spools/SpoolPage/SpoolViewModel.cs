using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;

namespace MyPrintiverse.FilamentsModule.Spools.SpoolPage
{
    public class SpoolViewModel : DisplayItemViewModel<Spool, EditSpoolView>
    {
        public SpoolViewModel(SpoolService spoolService)
        {
            ItemService = spoolService;
        }
    }
}
