using System.Data.SqlClient;

public class DataService()
{
    private readonly string connectionString = "Server=localhost,1433;Database=YourDatabase;User Id=sa;Password=YourStrong!Passw0rd;";
    public List<Fruit> GetAllFruit()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Fruits", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            var allFruits = new List<Fruit>();
            while (reader.Read())
            {
                var name = reader["Name"].ToString();
                var color = reader["Color"].ToString();

                var fruit = new Fruit
                {
                    Name = name,
                    Color = color
                };

                allFruits.Add(fruit);
            }

            return allFruits;
        }
    }

    public void AddFruit(string name, string color)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Fruits (name, color) VALUES (@name, @color)", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateFruit(string name, string color, int id)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            // Update
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Fruits SET Name = @name, Color = @color WHERE Id = @Id", conn);
            cmdUpdate.Parameters.AddWithValue("@Name", name);
            cmdUpdate.Parameters.AddWithValue("@Color", color);
            cmdUpdate.Parameters.AddWithValue("@Id", id);
            cmdUpdate.ExecuteNonQuery();

        }
    }

    public void DeleteFruit(int id)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Fruits WHERE Id = @Id", conn);
            cmdDelete.Parameters.AddWithValue("@Id", id);
            cmdDelete.ExecuteNonQuery();
        }
    }
}