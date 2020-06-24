using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDiagram
{
    public interface IRequestHandler<T> where T:IRequest 
    {
    }
}
