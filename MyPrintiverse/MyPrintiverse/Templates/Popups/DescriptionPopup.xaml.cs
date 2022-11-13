using CommunityToolkit.Maui.Views;

namespace MyPrintiverse.Templates.Popups;

public partial class DescriptionPopup : Popup
{
	public DescriptionPopup(string description)
	{
        InitializeComponent();
        this.header.ImageCommand = new Command(() => { this.Close(); });
        this.description.Text = string.IsNullOrEmpty(description) ? "Note not provided." : description;
    }

}