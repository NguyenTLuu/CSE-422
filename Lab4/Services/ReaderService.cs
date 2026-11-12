using Lab4.Interfaces;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderService(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public void AddReader(Reader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.Id <= 0)
                throw new ArgumentException(
                    "Reader ID must be positive.");

            if (string.IsNullOrWhiteSpace(reader.Name))
                throw new ArgumentException(
                    "Reader name is required.");

            if (_readerRepository.GetById(reader.Id) != null)
                throw new InvalidOperationException(
                    "Reader ID already exists.");

            _readerRepository.Add(reader);
        }

        public Reader? GetReaderById(int id)
        {
            return _readerRepository.GetById(id);
        }
    }
}
