using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ootpisp2
{
    public class Catalog
    {
        List<Film> films = new List<Film>();

        string className = "catalog";
        public List<Film> Films { get => films; set => films = value; }

        public void AddFilm(Film film)
        {
            MessageBox.Show($"Вызван AddFilm класса {className}");
            Films.Add(film);
        }

        public void DeleteFilm(int id)
        {
            MessageBox.Show($"Вызван DeleteFilm класса {className}");
            Films.RemoveAt(id);
        }

        public string SeeAllFilms()
        {
            MessageBox.Show($"Вызван SeeAllFilms класса {className}");
            string output = "";
            output += "id Name\t\tYear\tRating\tCountry\t\tType" + "\r\n";
            for (int i = 0; i < Films.Count; i++)
            {
                output += i + ". " + Films[i].SeeInformation() + "\r\n";
                output += "\n";
            }
            return output;
        }
    }
}
