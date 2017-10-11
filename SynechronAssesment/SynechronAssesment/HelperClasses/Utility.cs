using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynechronAssesment.HelperClasses
{
    public enum Profession
    {
        Default = -1,
        Doctor,
        SoftwareEngineer,
        Student,
        SportsPerson,
        Other
    }

    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
