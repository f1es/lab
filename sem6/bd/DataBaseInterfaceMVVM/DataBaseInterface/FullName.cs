using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseInterface
{
	public struct FullName
	{
		private readonly string _firstName;
		private readonly string _middleName;
		private readonly string _lastName;

		public string FirstName { get => _firstName; }
		public string MiddleName { get => _middleName; }
		public string LastName { get => _lastName; }

		public FullName(string firstName, string middleName, string lastName)
		{
			_firstName = firstName;
			_middleName = middleName;
			_lastName = lastName;
		}

		public FullName(string fullName)
		{
			string[] strings = fullName.Split(' ');
			_firstName = strings[0];
			_middleName = strings[1];
			_lastName = strings[2];
		}

		public List<string> ToList()
		{
			var list = new List<string>();
			list.Add(_firstName);
			list.Add(_middleName);
			list.Add(_lastName);
			return list;
		}

		public string[] ToArray()
		{
			string[] fullName = new string[3];
			fullName[0] = _firstName;
			fullName[1] = _middleName;
			fullName[2] = _lastName;
			return fullName;
		}

		public override string ToString()
		{
			return $"{_firstName} {_middleName} {_lastName}";
		}

		public static bool operator==(FullName fullName1, FullName fullName2)
		{
			if (fullName1.FirstName == fullName2.FirstName &&
				fullName1.MiddleName == fullName2.MiddleName &&
				fullName1.LastName == fullName2.LastName)
				return true;
			else
				return false;
		}

		public static bool operator !=(FullName fullName1, FullName fullName2)
		{
			if (fullName1.FirstName == fullName2.FirstName &&
				fullName1.MiddleName == fullName2.MiddleName &&
				fullName1.LastName == fullName2.LastName)
				return false;
			else
				return true;
		}
	}
}
