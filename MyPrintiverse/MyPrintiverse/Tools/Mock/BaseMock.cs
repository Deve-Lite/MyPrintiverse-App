
using MongoDB.Bson;

namespace MyPrintiverse.Tools.Mock;

public abstract class BaseMock<T> where T : BaseModel
{
    protected bool Rand() => new Random().Next() % 2==0 ? false : true;
    protected int Rand(int min, int max) => new Random().Next(min, max);
    protected double Rand(double max) => (new Random().NextDouble())*max;


    protected T GetRandomFromList<T>(List<T> data) => data[Rand(0, data.Count-1)];

    public void FillBaseData(T item)
    {
        item.Id = ObjectId.GenerateNewId().ToString();
        item.EditedAt = DateTime.Now;
        item.CreatedAt = DateTime.Now;
    }
}
