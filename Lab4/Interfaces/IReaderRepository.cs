using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Interfaces
{
    public interface IReaderRepository
    {
        void Add(Reader reader);
        Reader? GetById(int id);
        List<Reader> GetAll();
    }
}
