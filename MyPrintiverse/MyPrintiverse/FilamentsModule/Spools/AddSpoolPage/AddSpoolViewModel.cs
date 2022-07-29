
namespace MyPrintiverse.FilamentsModule.Spools.AddSpoolPage
{
    public class AddSpoolViewModel : BaseAddItemViewModel<Spool>
    {
        public AddSpoolViewModel(MessageService messageService, SpoolService itemService) : base(messageService, itemService)
        {
        }
    }
}
