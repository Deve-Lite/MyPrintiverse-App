using System;
using System.Collections.ObjectModel;

namespace MyPrintiverse.Utils.Base
{
	public class GrouppedItem<Model> : List<Model>
    {
        public string Name { get; set; }

        public ObservableCollection<Model> Collection { get; set; }

        public GrouppedItem(string name, ObservableCollection<Model> collection)
        {
            Name = name;
            Collection = new ObservableCollection<Model>(collection);
        }

        public GrouppedItem(string name)
        {
            Name = name;
            Collection = new ObservableCollection<Model>();
        }
    }
}

