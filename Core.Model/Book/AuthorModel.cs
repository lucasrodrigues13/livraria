using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class AuthorModel : BaseModel
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
