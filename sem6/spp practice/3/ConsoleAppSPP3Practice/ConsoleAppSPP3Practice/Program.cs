using ConsoleAppSPP3Practice;

public class Program
{
	static void Main()
	{
		Employee employee = new Employee() { Name = "q", Age = 21, Email = "qqq@mail.net" };
		Director director = new Director() { Name = "Sergey", Age = 21 };

		MarketBDContext.GetInstance().Employees.Add(employee);
		MarketBDContext.GetInstance().Directors.Add(director);
		MarketBDContext.GetInstance().SaveChanges();

		List<Employee> emps = new List<Employee>();
		emps.Add(MarketBDContext.GetInstance().Employees.FirstOrDefault());


		Department department = new Department() 
		{ Name = "Cool Department", Employees = emps, Directors = MarketBDContext.GetInstance().Directors.FirstOrDefault() };

		MarketBDContext.GetInstance().Departments.Add(department);
		MarketBDContext.GetInstance().SaveChanges();


		Console.WriteLine("Done!");
	}
}
