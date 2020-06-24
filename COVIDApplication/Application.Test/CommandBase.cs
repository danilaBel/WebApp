using Infrastructure_;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Test
{
    public class CommandTestBase : IDisposable
    {
        protected readonly AppDBContext _context;

        public CommandTestBase()
        {
            _context = AppDbContextFactory.Create();
        }

        public void Dispose()
        {
            AppDbContextFactory.Destroy(_context);
        }
    }
}
