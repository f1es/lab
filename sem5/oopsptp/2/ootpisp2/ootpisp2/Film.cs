using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ootpisp2
{
    public class Film
    {
        string name;
        int year;
        string type;
        int rating;
        string country;

        string className;
        int classNumber;

        public string Name { get => name; set => name = value; }
        public int Year { get => year; set => year = value; }
        public string Type { get => type; set => type = value; }
        public int Rating { get => rating; set => rating = value; }
        public string Country { get => country; set => country = value; }

        public Film() 
        {
            classNumber = CorrectInput.classCounter++;
            className = "Film";
        }
        public bool AddName(string _name)
        {
            MessageBox.Show($"Вызван AddName класса {className} {classNumber}");
            if (!(_name == string.Empty))
            {
                Name = _name;
                return true;
            }
            else
                return false;
        }
        public bool AddYear(string _year)
        {
            MessageBox.Show($"Вызван AddYear класса {className} {classNumber}");
            if (int.TryParse(_year, out int year))
            {
                Year = year;
                return true;
            }
            else
                return false;
        }
        public bool AddType(string _type)
        {
            MessageBox.Show($"Вызван AddType класса {className} {classNumber}");
            if (!(_type == string.Empty))
            {
                Type = _type;
                return true;
            }
            else
                return false;
        }
        public bool AddRating(string _rating)
        {
            MessageBox.Show($"Вызван AddRating класса {className} {classNumber}");
            if (int.TryParse(_rating, out int rating))
            {
                Rating = rating;
                return true;
            }
            else
              return false;

        }
        public bool AddCountry(string _country)
        {
            MessageBox.Show($"Вызван AddCountry класса {className} {classNumber}");
            if (!(_country == string.Empty))
            {
                Country = _country;
                return true;
            }
            else
                return false;
        }
        public void Edit(string _name, string _year, string _type, string _rate, string _country)
        {
            MessageBox.Show($"Вызван Edit класса {className} {classNumber}");
            AddName(_name);
            AddYear(_year);
            AddType(_type);
            AddRating(_rate);
            AddCountry(_country);
        }
        public string SeeInformation()
        {
            MessageBox.Show($"Вызван SeeInformation класса {className} {classNumber}");
            string output;
            output = Name + "\t\t" + Year + "\t" + Rating + "\t" + Country + "\t\t" + Type;
            return output;
        }
    }
}
