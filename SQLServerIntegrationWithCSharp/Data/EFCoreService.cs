public class EFCoreService(AppDbContext context)
{
    public readonly AppDbContext Context = context;

    private void AddItem(string name, string color)
    {
        Context.Fruits.Add(new Fruit(name, color));
        Context.SaveChangesAsync();
    }

    private void EditItem(string name, string color, int id)
    {
        var updatedFruit = new Fruit(name, color)
        {
            Id = id
        };

        Context.Fruits.Update(updatedFruit);
        Context.SaveChanges();
    }

    private void DeleteItem(string name, string color, int id)
    {
        var toDeleteFruit = new Fruit(name, color)
        {
            Id = id
        };

        Context.Fruits.Remove(toDeleteFruit);
        Context.SaveChanges();
    }
}
