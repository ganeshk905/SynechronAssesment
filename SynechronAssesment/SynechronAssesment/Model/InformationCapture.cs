
using SynechronAssesment.HelperClasses;
using SynechronAssesment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynechronAssesment.Model
{
    public class InformationCapture : ViewModelBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CityOfResidence { get; set; }
      

        public string Email { get; set; }
    }


}
