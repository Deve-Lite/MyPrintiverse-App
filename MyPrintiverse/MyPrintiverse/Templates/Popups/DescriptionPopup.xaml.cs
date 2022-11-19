using CommunityToolkit.Maui.Views;

namespace MyPrintiverse.Templates.Popups;

public partial class DescriptionPopup : Popup
{
	public DescriptionPopup(string description, string title = "Note")
	{
        InitializeComponent();
        this.header.ImageCommand = new Command(() => { this.Close(); });
        this.header.Title = title;
        this.description.Text = string.IsNullOrEmpty(description) ? "Note not provided." : description;
    }
}