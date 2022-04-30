using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagEditor
{
    internal class Artist
    {

        /// <summary>
        /// Type of the artist. 
        /// </summary>
        public enum ArtistType
        {
            vocal,
            composer
        }

        /// <summary>
        /// Possible returnal values for functions.
        /// </summary>
        public enum Returns
        {
            OK,
            NotContains,
            AlreadyContains,
            Similar
        }
        /// <summary>
        /// Artists 
        /// </summary>
        private readonly List<Tuple<string,ArtistType>> artists = new List<Tuple<string, ArtistType>>();
        
        /// <summary>
        /// <see cref="Artist"/> get its values after <see cref="Music"/> initialization.
        /// </summary>
        static public List<Tuple<string, ArtistType>> Artists = new List<Tuple<string, ArtistType>>();



        /// <summary>
        /// Add artist to a song. Also to <see cref="Artists"/> if it does not contain.
        /// </summary>
        /// <param name="artistName">Name of the artist.</param>
        /// <param name="type">Artist type <see cref="ArtistType"/>.</param>
        /// <param name="forced">If the forced is true then the process will be forced to execute.</param>
        /// <returns>Returns a <see cref="Returns"/> value.</returns>
        public Returns Addartist(string artistName, ArtistType type, bool forced = false)
        {
            if (forced)
            {
                artists.Add(Tuple.Create(artistName, type));
                if (Artists.All(x => x.Item1 != artistName && x.Item2 != type))
                    Artists.Add(Tuple.Create(artistName, type));
                return Returns.OK;
            }
            if (artists.Any(x => x.Item1 == artistName && x.Item2 == type))
                return Returns.AlreadyContains;
            if (artists.Any(x => x.Item1 == artistName || x.Item2 == type))
                return Returns.Similar;
            artists.Add(Tuple.Create(artistName, type));
            if (Artists.All(x => x.Item1 != artistName && x.Item2 != type))
                Artists.Add(Tuple.Create(artistName, type));
            return Returns.OK;
        }
        /// <summary>
        /// Add artist to a song. Also to <see cref="Artists"/> if it does not contain.
        /// </summary>
        /// <param name="artist">The artist name + <see cref="ArtistType"/></param>
        /// <param name="forced">If the forced is true then the process will be forced to execute.</param>
        /// <returns>Returns a <see cref="Returns"/> value.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Returns Addartist(Tuple<string,ArtistType> artist, bool forced = false)
        {
            if (artist == null)
            {
                throw new ArgumentNullException();
            }
            if (forced)
            {
                artists.Add(Tuple.Create(artist.Item1, artist.Item2));
                if (Artists.All(x => x.Item1 != artist.Item1 && x.Item2 != artist.Item2))
                    Artists.Add(Tuple.Create(artist.Item1, artist.Item2));
                return Returns.OK;
            }
            if (artists.Any(x => x.Item1 == artist.Item1 && x.Item2 == artist.Item2))
                return Returns.AlreadyContains;
            if (artists.Any(x => x.Item1 == artist.Item1 || x.Item2 == artist.Item2))
                return Returns.Similar;
            artists.Add(Tuple.Create(artist.Item1, artist.Item2));
            if (Artists.All(x => x.Item1 != artist.Item1 && x.Item2 != artist.Item2))
                Artists.Add(Tuple.Create(artist.Item1, artist.Item2));
            return Returns.OK;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        /// <exception cref="EmptyListException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Returns Removeartist(int ind)
        {
            if (artists.Count == 0)
                throw new EmptyListException();
            if (ind < 0 || ind >= artists.Count)
                throw new ArgumentOutOfRangeException();
            artists.RemoveAt(ind);
            return Returns.OK;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="EmptyListException"></exception>
        public Returns Removeartist(string name)
        {
            if (artists.Count == 0)
                throw new EmptyListException();
            artists.Remove(artists.First(x => x.Item1 == name));
            return Returns.OK;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="EmptyListException"></exception>
        public Returns Removeartist(string name, ArtistType type)
        {
            if (artists.Count == 0)
                throw new EmptyListException();
            artists.Remove(artists.First(x => x.Item1 == name && x.Item2 == type));
            return Returns.OK;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        /// <exception cref="EmptyListException"></exception>
        public Returns Removeartist(Tuple<string, ArtistType> artist)
        {
            if (artists.Count == 0)
                throw new EmptyListException();
            artists.Remove(artist);
            return Returns.OK;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="artistName"></param>
        /// <param name="type"></param>
        public static void AddArtist(string artistName, ArtistType type)
        {
            Artists.Add(Tuple.Create(artistName, type));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="artist"></param>
        public static void AddArtist(Tuple<string, ArtistType> artist)
        {
            Artists.Add(Tuple.Create(artist.Item1, artist.Item2));
        }
    }
}
