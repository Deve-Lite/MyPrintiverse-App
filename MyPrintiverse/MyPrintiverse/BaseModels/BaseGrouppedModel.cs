namespace MyPrintiverse.BaseModels;
/// <summary>
/// Base model for grouped CollectionView.
/// </summary>
/// <typeparam name="T"> Collection Model </typeparam>
public class GroupedItem<T> : ObservableCollection<T>
{
	/// <summary>
	/// Stores group name for display in view and group identification.
	/// </summary>
	public string Name { get; set; }

	public GroupedItem(string name, IEnumerable<T> collection)
		: base(collection)
	{
		Name = name;
	}

	public GroupedItem(string name)
		: base(new ObservableCollection<T>())
	{
		Name = name;
	}
}