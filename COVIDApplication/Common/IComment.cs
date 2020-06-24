using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface IComment<key,message>
    {
        key From { get; set; }
        key To { get; set; }
        message Message { get; set; }
    }
}
