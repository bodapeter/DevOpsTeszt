using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWord.Bll.Models
{
    public class Greeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }

        public Greeting()
        {

        }

        public Greeting(string name)
        {
            Name = name;
            TimeStamp = DateTime.Now;
        }
    }
}
