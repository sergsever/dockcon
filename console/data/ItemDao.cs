using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.data
{
	public class ItemDao
	{
		private DataContext dbcontext { get; set; }
		public ItemDao(DataContext dbcontext) 
		{
			this.dbcontext = dbcontext;
		}
		public void Add(Item item) 
		{ 
			dbcontext.Items.Add(item);
			dbcontext.SaveChanges();
		}

		public Item GetFirst()
		{
			return dbcontext.Items.FirstOrDefault();
		}

		public IEnumerable<Item> GetAll()
		{
			return dbcontext.Items.ToList();
		}


	}
}
