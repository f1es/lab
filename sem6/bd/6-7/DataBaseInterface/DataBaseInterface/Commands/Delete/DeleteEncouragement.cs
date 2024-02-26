using DataBaseInterface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataBaseInterface.Commands.Delete
{
	public class DeleteEncouragement : ICommand
	{
		private int _id;
		private IS_Buro_KadrovContext _context;
		public DeleteEncouragement(IS_Buro_KadrovContext context)
		{
			_context = context;
			//_id = id;
		}

		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			
			throw new NotImplementedException();
		}

		public void Execute(object? parameter)
		{
			var encour = _context.Encouragements.Where(x => x.Id == ((int)parameter)).Single();
			_context.Encouragements.Remove(encour);
		}
	}
}
