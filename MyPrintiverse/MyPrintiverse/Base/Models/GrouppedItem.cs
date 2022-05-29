﻿namespace MyPrintiverse.Base.Models
{
    /// <summary>
    /// Base model for groupped CollectionView.
    /// </summary>
    /// <typeparam name="T"> Collection Model </typeparam>
    public class GrouppedItem<T> : ObservableCollection<T>
    {
        /// <summary>
        /// Stores group name for display in view and group identification.
        /// </summary>
        public string Name { get; set; }

        public ObservableCollection<T> Items { get; set; }

        public GrouppedItem(string name, ObservableCollection<T> collection)
        {
            Name = name;
            Items = new ObservableCollection<T>(collection);
        }

        public GrouppedItem(string name)
        {
            Name = name;
            Items = new ObservableCollection<T>();
        }
    }
}

