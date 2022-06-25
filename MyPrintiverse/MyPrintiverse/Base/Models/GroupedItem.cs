namespace MyPrintiverse.Base.Models
{
    /// <summary>
    /// Base model for grouped CollectionView.
    /// </summary>
    /// <typeparam name="T"> Collection Model </typeparam>
    public class GroupedItem<T> : ObservableCollection<T>
    {
        /// <summary>
        /// Stores group name for display in view and group identification.
        /// </summary>
        public string Name { get; private set; }


        public GroupedItem(string name, ObservableCollection<T> collection) : base(collection)
        {
            Name = name;
        }
    }
}

