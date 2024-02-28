using DataBaseInterface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseInterface.Models
{
    public class DirectorsNames
    {
        private IS_Buro_KadrovContext _db;
        public DirectorsNames(IS_Buro_KadrovContext db)
        {
            _db = db;
        }
        public List<FullName> GetDirectorsFullNames()
        {
            return _db.Directors.Select(dir => dir.FullName).ToList();
        }
        public List<string> GetDirectorsFullNamesAsString()
        {
            List<string> fullNames = new List<string>();
            foreach (var name in GetDirectorsFullNames())
                fullNames.Add(name.ToString());
            return fullNames;
        }
        public FullName GetDirectorFullNameById(int id)
        {
            var director = _db.Directors.Where(dir => dir.Id == id).Single();
            return director.FullName;
        }

        public int GetDirectorIdByFullName(FullName fullName)
        {
            int id;
            id = _db.Directors
                .Where(
                dir => dir.FirstName == fullName.FirstName &&
                dir.MiddleNames == fullName.MiddleName &&
                dir.LastName == fullName.LastName)
                .Single().Id;
            return id;
        }

        public List<FullName> GetExceptDirectorsNames()
        {
            List<int> existDirectors = new List<int>();
            foreach (var comp in _db.Companies.ToList())
            {
                existDirectors.Add(comp.DirectorId);
            }

            List<int> allDirectors = new List<int>();
            foreach (var dir in _db.Directors.ToList())
            {
                allDirectors.Add(dir.Id);
            }

            List<Director> directors = new List<Director>();
            foreach (var name in GetDirectorsFullNames())
            {
                directors.Add(_db.Directors.Where(dir => dir.Id == GetDirectorIdByFullName(name)).Single());
            }

            List<int> directorsId = allDirectors.Except(existDirectors).ToList();
            List<FullName> names = new List<FullName>();
            foreach (var id in directorsId)
            {
                names.Add(_db.Directors.Where(dir => dir.Id == id).Single().FullName);
            }

            return names;
        }
    }
}
