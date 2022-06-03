

namespace MyPrintiverse.FilamentsModule.Prints.EditPrintPage
{
    public class EditPrintViewModel : EditItemViewModel<Print>
    {
        public EditPrintViewModel(PrintService printService)
        {
            ItemService = printService;
        }
    }
}
