using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary
{
    class GenreMapper : AbstractMapper<Genre>
    {
        public override HashSet<Genre> GetData()
        {
            List<Genre> list = new List<Genre>();
            try
            {
                cn.Open();
                String query = "SELECT * FROM Genre Order By Name";
                SqlCommand command = new SqlCommand(query, cn);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Genre genre = new Genre(reader.GetInt32(0),
                                                reader.GetString(1));
                        list.Add(genre);
                    }
                }
                reader.Close();
            }
            finally
            {
                cn.Close();
            }

            return new HashSet<Genre>(list);
        }

        public override void InsertOrUpdate(Genre data)
        {
            try
            {
                cn.Open();
                String query = "IF EXISTS (SELECT * FROM Genre WHERE Id = @Id OR Name=@Name) " +
                "BEGIN UPDATE Genre SET Name=@Name WHERE Id = @Id END ELSE " +
                "BEGIN INSERT Genre (Name) VALUES (@Name) END";

                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Id", data.id);
                command.Parameters.AddWithValue("@Name", data.name);

                command.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }
        }

        public override void deleteData(Genre data)
        {
            try
            {
                cn.Open();
                String query = "DELETE FROM Genre WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Id", data.id);

                command.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
