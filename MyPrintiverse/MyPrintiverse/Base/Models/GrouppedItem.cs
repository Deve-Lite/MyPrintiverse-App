namespace MyPrintiverse.Base.Models
{
    /// <summary>
    /// Base model for groupped CollectionView.
    /// </summary>
    /// <typeparam name="Model"></typeparam>
    public class GrouppedItem<Model> : ObservableCollection<Model>
    {
        /// <summary>
        /// Identify group by name.
        /// </summary>
        public string Name { get; set; }

        public ObservableCollection<Model> Items { get; set; }

        public GrouppedItem(string name, ObservableCollection<Model> collection)
        {
            Name = name;
            Items = new ObservableCollection<Model>(collection);
        }

        public GrouppedItem(string name)
        {
            Name = name;
            Items = new ObservableCollection<Model>();
        }
    }
}

