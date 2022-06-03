

namespace MyPrintiverse.FilamentsModule.Prints.AddPrintPage
{
    public class AddPrintViewModel : AddItemViewModel<Print>
    {
        public AddPrintViewModel(PrintService printService)
        {
            ItemService = printService;
        }
    }
}
