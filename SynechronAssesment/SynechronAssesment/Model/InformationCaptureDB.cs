using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynechronAssesment.Model
{
    public class InformationCaptureDB:DbContext
    {
        public InformationCaptureDB():base("name=DefaultConnection")
        {

        }

        public DbSet<InformationCapture> Person { get; set; }
    }
}
