using System;
using System.Collections.Generic;
using System.Text;

namespace SmartphoneConsole
{
    public class BaseApp
    {
        public string Name { get; private set; }
        public double SizeInMB { get; private set; }
        public string Description { get; private set; }

        public BaseApp(string name, double megabyte, string description)
        {
            Name = name;
            SizeInMB = megabyte;
            Description = description;
        }

        public virtual string Start()
        {
            return Name + " - " + ToString() + " wird gestartet";
        }

        public override string ToString()
        {
            return "App";
        }
    }
}
