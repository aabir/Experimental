using System;

namespace PostGreBE.Entity
{
    public class Tutorial
    {
        public Guid id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }
    }
}
