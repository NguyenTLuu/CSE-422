using Microsoft.Data.SqlClient;

namespace Exercise2.Repositories
{
    public class GenericRepository<T> : IRepository<T>
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly Func<SqlDataReader, T> _mapper;

        public GenericRepository(
            string connectionString,
            string tableName,
            Func<SqlDataReader, T> mapper)
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _mapper = mapper;
        }

        public List<T> GetAll()
        {
            var items = new List<T>();

            using var connection =
                new SqlConnection(_connectionString);

            connection.Open();

            using var command = new SqlCommand(
                $"SELECT Id, Name FROM {_tableName}",
                connection
            );

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                items.Add(_mapper(reader));
            }

            return items;
        }
    }
}