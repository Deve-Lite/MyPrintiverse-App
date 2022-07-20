using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;

namespace MyPrintiverse.FilamentsModule.Spools.SpoolPage
{
    public class SpoolViewModel : BaseItemViewModel<Spool, EditSpoolView>
    {

        public SpoolViewModel(MessageService messageService, SpoolService itemService) : base(messageService, itemService)
        {
        }
    }
}
