using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace VideoLibrary
{
    public class MovieManager
    {
        private HashSet<Movie> movies;
        private HashSet<Selectable<Genre>> genres;
        private MovieMapper movieMapper = new MovieMapper();
        private GenreMapper genreMapper = new GenreMapper();

        public MovieManager()
        {
            movies = new HashSet<Movie>(movieMapper.GetData());
            NewGenres();
        }

        private void NewGenres()
        {
            genres = new HashSet<Selectable<Genre>>();
            foreach (Genre genre in genreMapper.GetData())
            {
                genres.Add(new Selectable<Genre>(genre));
            }
        }

        public List<Movie> GetAllNewMovies(string path)
        {
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            

            List<Movie> newMovies = new List<Movie>();

            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".wmv", StringComparison.OrdinalIgnoreCase) ||
                   s.EndsWith(".avi", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".mkv", StringComparison.OrdinalIgnoreCase) || 
                   s.EndsWith(".mpeg", StringComparison.OrdinalIgnoreCase));

            bool exists = false;
            foreach(String s in files) 
            {
                

                exists = false;
                foreach (Movie m in movies)
                {
                    if (m.location == s)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    IWMPMedia clip = player.newMedia(s);
                    MemoryStream stream = new MemoryStream();
                    var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                    ffMpeg.GetVideoThumbnail(s, stream, (float)clip.duration / 10);

                    
                    newMovies.Add(new Movie(0, Path.GetFileName(s), (int)clip.duration, s, "", new Bitmap(stream)));
                }
                
            }

            return newMovies;
        }

        public HashSet<Movie> getMoviesWithFilter(string text)
        {
            List<Movie> rList = new List<Movie>(movies);
            for (int i = rList.Count - 1; i >= 0; i-- )
            {
                if (text != "" && (!rList[i].name.Contains(text) && !rList[i].description.Contains(text)))
                {
                    rList.RemoveAt(i);
                    continue;
                }
                bool contained = true;
                foreach (Selectable<Genre> genre in getSearchTags())
                {
                    if ((!rList[i].genres.Contains(genre.item, new Compare())  && !genre.notThat) || (rList[i].genres.Contains(genre.item, new Compare()) && genre.notThat))
                    {
                        contained = false;
                        break;
                    }
                }
                if (!contained)
                {
                    rList.RemoveAt(i);
                }
            }

            return new HashSet<Movie>(rList);
        }

        public void InsertOrUpdateMovie(Movie movie)
        {
            movieMapper.InsertOrUpdate(movie);
        }

        public void UpdateMovieList()
        {
            movies.Clear();
            movies = movieMapper.GetData();
        }

        public void InsertOrUpdateGenre(Genre genre)
        {
            genreMapper.InsertOrUpdate(genre);
            NewGenres();
        }

        public void DeleteMovie(Movie movie)
        {
            movieMapper.deleteData(movie);
            movies.Remove(movie);
        }

        public void DeleteGenre(Genre genre)
        {
            genreMapper.deleteData(genre);
            NewGenres();
        }

        public HashSet<Movie> getMovies()
        {
            return movies;
        }

        public HashSet<Genre> getGenres()
        {
            HashSet<Genre> list = new HashSet<Genre>();
            foreach (Selectable<Genre> gen in genres)
            {
                list.Add(gen.item);
            }
            return list;
        }

        public List<Selectable<Genre>> getAllSearchTags(string filter = "")
        {
            if (string.IsNullOrEmpty(filter))
                return genres.ToList();
            return genres.Where(g => g.item.name.ToLower().Contains(filter.ToLower())).ToList();
        }

        private HashSet<Selectable<Genre>> getSearchTags()
        {
            HashSet<Selectable<Genre>> list = new HashSet<Selectable<Genre>>();
            foreach (Selectable<Genre> gen in genres)
            {
                if (gen.selected)
                {
                    list.Add(gen);
                }
            }
            return list;
        }

        public List<KeyValuePair<string, int>> getMostUsedGenres()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (Movie m in movies)
            {
                foreach (Genre g in m.genres)
                {
                    if (dic.ContainsKey(g.name))
                    {
                        dic[g.name] += 1;
                    }
                    else
                    {
                        dic.Add(g.name, 1);
                    }
                }
            }
            List<KeyValuePair<string, int>> myList = dic.ToList();

            myList.Sort((firstPair, nextPair) =>
            {
                return firstPair.Value.CompareTo(nextPair.Value);
            }
            );
            myList.Reverse();
            return myList;
        }
    }

    class Compare : IEqualityComparer<Genre>
    {
        public bool Equals(Genre x, Genre y)
        {
            return x.name == y.name;
        }
        public int GetHashCode(Genre codeh)
        {
            return codeh.GetHashCode();
        }
    }
}
