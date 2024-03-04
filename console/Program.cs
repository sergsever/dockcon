// See https://aka.ms/new-console-template for more information
using console.data;
using Microsoft.Extensions.Configuration;
using System.Configuration;
internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("Hello !");

		DataContext dbcontext = new DataContext();
		dbcontext.Init();
		ItemDao dao = new ItemDao(dbcontext);
		dao.Add(new Item() { Name = "Item1" });
		Console.WriteLine(dao.GetFirst().ToString());
	}
}