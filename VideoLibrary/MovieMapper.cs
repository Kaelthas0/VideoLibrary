using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary
{
    class MovieMapper : AbstractMapper<Movie>
    {
        public override HashSet<Movie> GetData()
        {
            List<Movie> list = new List<Movie>();
            try
            {
                cn.Open();
                cn2.Open();
                String query = "SELECT * FROM Movie";
                SqlCommand command = new SqlCommand(query, cn);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        Bitmap bmp = null;
                        try
                        {

                            var ms = new MemoryStream((Byte[])reader.GetValue(5));

                            bmp = new Bitmap(ms);

                        }
                        catch { }
                        Movie movie = new Movie(reader.GetInt32(0),
                                                reader.GetString(1),
                                                reader.GetInt32(2),
                                                reader.GetString(3),
                                                reader.GetString(4),
                                                bmp);

                        

                        list.Add(movie);
                    }
                    
                }
                reader.Close();
                GetGenresForMovie(list);
            }
            finally
            {
                cn.Close();
                cn2.Close();
            }

            return new HashSet<Movie>(list);
        }

        private void GetGenresForMovie(List<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                String gQuery = "SELECT * FROM Genre WHERE Id IN (SELECT GenreId FROM MovGen WHERE MovieId = @MovieId)";
                SqlCommand gCommand = new SqlCommand(gQuery, cn2);
                gCommand.Parameters.AddWithValue("@MovieId", movie.id);
                SqlDataReader gReader = gCommand.ExecuteReader();

                if (gReader.HasRows)
                {
                    while (gReader.Read())
                    {
                        movie.genres.Add(new Genre(gReader.GetInt32(0),
                                                   gReader.GetString(1)));
                    }
                }
                gReader.Close();
            }
        }

        public override void InsertOrUpdate(Movie data)
        {
            try
            {
                Byte[] bmp = new Byte[1];
                using (var ms = new MemoryStream())
                {
                    try
                    {
                        data.image.Save(ms, ImageFormat.Jpeg);
                        bmp = ms.ToArray();
                    }
                    catch { }
                }

                cn.Open();
                String query = "IF EXISTS (SELECT * FROM Movie WHERE Id = @Id OR Name = @Name) " +
                "BEGIN UPDATE Movie SET Name=@Name, Length=@Length, Location=@Location, Description=@Description, Image=@Image WHERE Id = @Id END ELSE " + 
                "BEGIN INSERT Movie (Name, Length, Location, Description, Image) OUTPUT INSERTED.ID VALUES (@Name, @Length, @Location, @Description, @Image) END";

                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Id", data.id);
                command.Parameters.AddWithValue("@Name", data.name);
                command.Parameters.AddWithValue("@Length", data.length);
                command.Parameters.AddWithValue("@Location", data.location);
                command.Parameters.AddWithValue("@Description", data.description);
                command.Parameters.AddWithValue("@Image", bmp);

                try
                {
                    data.id = (Int32)command.ExecuteScalar();
                }
                catch { }
                InsertAllGenres(data, ref query, ref command);
            }
            finally
            {
                cn.Close();
            }
        }

        private void InsertAllGenres(Movie data, ref String query, ref SqlCommand command)
        {
            foreach (Genre genre in data.genres)
            {
                query = "IF NOT EXISTS (SELECT * FROM MovGen WHERE MovieId = @MovieId AND GenreId = @GenreId)" +
                        "BEGIN INSERT MovGen (MovieId, GenreId) VALUES (@MovieId, @GenreId) END";
                command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@MovieId", data.id);
                command.Parameters.AddWithValue("@GenreId", genre.id);
                command.ExecuteNonQuery();
            }
        }

        public override void deleteData(Movie data)
        {
            try
            {
                cn.Open();

                String query = "DELETE FROM MovGen WHERE MovieId = @MovieId";
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@MovieId", data.id);
                command.ExecuteNonQuery();


                query = "DELETE FROM Movie WHERE Id = @Id";

                command = new SqlCommand(query, cn);
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
