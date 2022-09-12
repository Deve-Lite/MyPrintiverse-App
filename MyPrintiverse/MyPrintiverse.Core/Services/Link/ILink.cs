namespace MyPrintiverse.Core.Services.Link
{
    public interface ILink<T>
    {
        public string GetItem(string id);
        public string GetItems();
        public string AddItem();
        public string UpdateItem(string id);
        public string DeleteItem(string id);
        public string DeleteItems();
    }
}
