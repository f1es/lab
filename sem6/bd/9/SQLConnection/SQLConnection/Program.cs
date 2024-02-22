using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

class Program
{
    static async Task Main()
    {
		//string connectionString = "Server=(localdb)\\mssqllocaldb;Database=buroKadrov;Trusted_Connection=True;";
		//string login = "DmitriyLogin";
		//string password = "123";

		await DoSomething("DmitriyLogin", "123");
		await DoSomething("AdminLogin", "admin");
		await DoSomething("IvanLogin", "123");
    }

	// Console.WriteLine("he");
	public static async Task WriteTable(SqlDataReader reader)
    {
		if (reader.HasRows) // если есть данные
		{
			// выводим названия столбцов
			//Console.WriteLine($"{columnName1}\t{columnName3}\t{columnName2}");

			for (int i = 0; i < reader.FieldCount; i++)
			{
				object value = reader.GetName(i);
				try
				{
					string stringValue = value.ToString();
					while (stringValue.Length < 10)
					{
						stringValue += ' ';
					}
					Console.Write($"{stringValue}\t");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					break;
				}
			}
			Console.WriteLine();

			while (await reader.ReadAsync()) // построчно считываем данные
			{

				for (int i = 0; i < reader.FieldCount; i++)
				{
					object value = reader.GetValue(i);
					try
					{

						string stringValue = value.ToString();
						while (stringValue.Length < 10)
						{
							stringValue += ' ';
						}
						Console.Write($"{stringValue}\t");
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
						break;
						//value = null;
					}
				}

				Console.WriteLine();
			}
		}
	}
	public static async Task DoSomething(string login, string password)
	{
		string connectionString = $"Server=(localdb)\\mssqllocaldb;Database=buroKadrov;User Id={login};Password={password};";
		SqlConnection connection = new SqlConnection(connectionString);

		// Открываем подключение
		await connection.OpenAsync();
		Console.WriteLine("Подключение открыто");
		Console.WriteLine("Connected with " + connection.Database.ToString());
		Console.WriteLine("Client Connection id " + connection.ClientConnectionId.ToString());

		SqlCommand command = new SqlCommand("SELECT * FROM WorkersSchema.Workers");
		command.Connection = connection;
		try
		{
			SqlDataReader reader = await command.ExecuteReaderAsync();
			await WriteTable(reader);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}


		if (connection.State == ConnectionState.Open)
		{
			// закрываем подключение
			await connection.CloseAsync();
			Console.WriteLine("Подключение закрыто...");
		}

		Console.Read();
	}
}