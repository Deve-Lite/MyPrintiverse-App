using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;

namespace MyPrintiverse.FilamentsModule.Spools.SpoolPage
{
    public class SpoolViewModel : BaseItemViewModel<Spool, EditSpoolView>
    {
        public SpoolViewModel(SpoolService itemService) : base(itemService)
        {
        }
    }
}
