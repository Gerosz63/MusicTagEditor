using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MusicTagEditor
{
    internal class Genre
    {
        // Fields

        /// <summary>
        /// Contains the genres of a music.
        /// </summary>
        private List<string> genres = new List<string>();

        /// <summary>
        /// Contains all available genres.
        /// </summary>
        static public List<string> Genres = new List<string>();

        /// <summary>
        /// Name of the genre file.
        /// </summary>
        static private string genresFile = "genres.txt";

        /// <summary>
        /// An enum for the potetional errors or return values.
        /// </summary>
        public enum state
        {
            OK,
            similar,
            contains,
            error
        }

        /// <summary>
        /// Add genre to the object.
        /// </summary>
        /// <param name="genre">Name of the genre type</param>
        public void AddGenre(string genre)
        {
            genres.Add(genre); 
        }

        /// <summary>
        /// Add new gernre type which the main genre container does not contain.
        /// </summary>
        /// <param name="genre">Name of the genre</param>
        /// <param name="forced">Force adding. The function dont make any warning.</param>
        /// <returns>
        /// <see cref="state"/> value:
        /// <list type="table">
        ///     <item>
        ///         <term><see cref="state.OK"/></term>
        ///         <description>Function executed successfully.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="state.contains"/></term>
        ///         <description><paramref name="genre"/> is in the list of <see cref="Genres"/></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="state.similar"/></term>
        ///         <description><see cref="Genres"/> contains a similar genre type.</description>
        ///     </item>
        /// </list>
        /// </returns>
        public state AddNewGenre(string genre, bool forced = false)
        {
            if (forced)
            {
                genres.Add(genre);
                Genre.AddGenres(genre);
                return state.OK;
            }
            if (Genres.Any(x => x.ToLower().Contains(genre.ToLower()) || genre.ToLower().Contains(x.ToLower())))
            {
                return state.similar;
            }
            else if (Genres.Contains(genre))
            {
                return state.contains;
            }
            else
            {
                genres.Add(genre);
                Genre.AddGenres(genre);
                return state.OK;
            }
        }


        /// <summary>
        /// Removes specified genre by name.
        /// </summary>
        /// <param name="genreName">Given genre name.</param>
        /// <exception cref="EmptyListException">Throws if the <see cref="genres"/> list is empty.</exception>
        /// <exception cref="ElementNotincludedException">Throws if the <see cref="genres"/> list is not contains <paramref name="genreName"/>.</exception>
        public void RemoveGenre(string genreName) 
        {
            if (genres.Count == 0)
            {
                throw new EmptyListException();
            }
            if (!genres.Remove(genreName))
            {
                throw new ElementNotincludedException();
            }
        }
        /// <summary>
        /// Remove genre at a given index.
        /// </summary>
        /// <param name="genreIndex">Given index</param>
        /// <exception cref="EmptyListException">Throws if the <see cref="genres"/> list is empty.</exception>
        /// <exception cref="IndexOutOfRangeException">Throws if the <paramref name="genreIndex"/> is a not valid index of <see cref="genres"/>.</exception>
        public void RemoveGenre(int genreIndex)
        {
            if (genres.Count == 0)
            {
                throw new EmptyListException();
            }
            else if (genreIndex < 0 || genreIndex >= genres.Count)
            {
                throw new IndexOutOfRangeException();
            }
            genres.RemoveAt(genreIndex);
        }

        /// <summary>
        /// Read data from the genre file upload it to <see cref="Genres"/>
        /// If the file does not exsist, the function will create it.
        /// </summary>
        static public void InitGenres()
        {
            Genres.Clear();
            if (File.Exists(genresFile))
            {
                StreamReader sr = new StreamReader(genresFile);
                while (!sr.EndOfStream)
                {
                    Genres.Add(sr.ReadLine());
                }
                sr.Close();
            }
            else
            {
                File.Create(genresFile).Close();
            }
        }

        /// <summary>
        /// Add new element to <see cref="Genres"/>, and add it to the genre file.
        /// </summary>
        /// <param name="genre">Name of the genre</param>
        static public void AddGenres(string genre)
        {
            Genres.Add(genre);
            using (StreamWriter streamWriter = File.AppendText(genresFile))
            {
                streamWriter.WriteLine(genre);
            }
        }

        /// <summary>
        /// Removes a genre from <see cref="Genres"/>
        /// </summary>
        /// <param name="genreName">Name of the genre</param>
        /// <exception cref="EmptyListException"></exception>
        /// <exception cref="ElementNotincludedException"></exception>
        public static void RemoveGenres(string genreName)
        {
            if (Genres.Count == 0)
            {
                throw new EmptyListException();
            }
            if (!Genres.Remove(genreName))
            {
                throw new ElementNotincludedException();
            }
            WriteFile();
        }

        /// <summary>
        /// Removes a genre from <see cref="Genres"/>
        /// </summary>
        /// <param name="genreIndex">Genre index</param>
        /// <exception cref="EmptyListException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static void RemoveGenres(int genreIndex)
        {
            if (Genres.Count == 0)
            {
                throw new EmptyListException();
            }
            else if (genreIndex < 0 || genreIndex >= Genres.Count)
            {
                throw new IndexOutOfRangeException();
            }
            Genres.RemoveAt(genreIndex);
            WriteFile();
        }

        /// <summary>
        /// Rewrite the genre file.
        /// </summary>
        private static void WriteFile()
        {
            StreamWriter genreFile = new StreamWriter(genresFile);
            foreach (var genre in Genres)
            {
                genreFile.WriteLine(genre);
            }
            genreFile.Close();
        }
    }
}
