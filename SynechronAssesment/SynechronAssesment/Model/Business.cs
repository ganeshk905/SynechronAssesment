using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynechronAssesment.Model
{
    public class Business
    {
        InformationDB _dbContext = null;
        public Business()
        {
            AppDomain.CurrentDomain.SetData("InformationDB",
             Environment.CurrentDirectory);
            _dbContext = new InformationDB();
        }

        internal IEnumerable<InformationCapture> Get()
        {
            return _dbContext.Person.ToList();
        }

        internal void Delete(InformationCapture person)
        {
            _dbContext.Person.Remove(person);
        }

        internal void Update(InformationCapture updatedPerson)
        {
            CheckValidations(updatedPerson);
            if (updatedPerson.Id > 0)
            {
                InformationCapture selectedPerson = _dbContext.Person.First(p => p.Id == updatedPerson.Id);
                selectedPerson.FirstName = updatedPerson.FirstName;
                selectedPerson.LastName = updatedPerson.LastName;
                selectedPerson.CityOfResidence = updatedPerson.CityOfResidence;
                // selectedPerson.Profession = updatedPerson.Profession;
                selectedPerson.Email = updatedPerson.Email;
            }
            else
            {
                _dbContext.Person.Add(updatedPerson);
            }

            _dbContext.SaveChanges();
        }

        private void CheckValidations(InformationCapture person)
        {


            if (string.IsNullOrEmpty(person.FirstName))
            {
                throw new ArgumentNullException("First Name", "Please enter FirstName");
            }
            else if (string.IsNullOrEmpty(person.LastName))
            {
                throw new ArgumentNullException("Last Name", "Please enter LastName");
            }

            else if (string.IsNullOrEmpty(person.Email))
            {
                throw new ArgumentNullException("Email", "Please enter Email");
            }
        }
    }
}
