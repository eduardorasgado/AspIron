using System;

namespace AspIron.Models
{
    public class Academy
    {
        public string AcademyId { get; private set; }
        public string Name { set; get; }
        public int FundationYear { set; get; }

        public Academy()
        {
            AcademyId = Guid.NewGuid().ToString();
        }
    }
}