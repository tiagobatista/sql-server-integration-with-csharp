public class EFCoreService(AppDbContext context)
{
    public readonly AppDbContext Context = context;

    public void AddFruit(string name, string color)
    {
        var fruit = new Fruit
        {
            Name = name,
            Color = color
        };

        Context.Fruits.Add(fruit);
        Context.SaveChangesAsync();
    }

    public void EditFruit(string name, string color, int id)
    {
        var updatedFruit = new Fruit
        {
            Name = name,
            Color = color,
            Id = id
        };


        Context.Fruits.Update(updatedFruit);
        Context.SaveChanges();
    }

    public void DeleteFruit(string name, string color, int id)
    {
        var toDeleteFruit = new Fruit
        {
            Id = id
        };

        Context.Fruits.Remove(toDeleteFruit);
        Context.SaveChanges();
    }
}
