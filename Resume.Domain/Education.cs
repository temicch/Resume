using System;

namespace Resume.Domain
{
    public class Education
    {
        public string Institution { get; set; }
        public string Qualification { get; set; }
        public DateTime YearOfStart { get; set; }
        public DateTime YearOfEnd { get; set; }
    }
}