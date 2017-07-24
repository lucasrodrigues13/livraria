using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class BookModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Edition { get; set; }
        public long ISBN { get; set; }
        public List<AuthorModel> Authors { get; set; }
        public PublisherModel Publisher { get; set; }
    }
}
