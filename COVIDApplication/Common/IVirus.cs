using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
   public interface IVirus
    {
        string Title { get; set; }
        string Description { get; set; }
        string TransPath { get; set; }
        string Symptoms { get; set; }

    }
}
