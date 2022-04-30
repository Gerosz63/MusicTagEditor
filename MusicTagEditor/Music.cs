using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MusicTagEditor
{
    /// <summary>
    /// Music data container and some useful fuctions
    /// <list type="table">
    ///     <item>
    ///         <term><see cref="path"/></term>
    ///         <description>Path of the music file</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="genre"/></term>
    ///         <description>The song genres</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="genre"/></term>
    ///         <description>The song genres</description>
    ///     </item>
    /// </list>
    /// </summary>
    internal class Music
    {
        public uint id;
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        private Genre genre;

        public Genre Genre
        {
            get { return genre; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string lyrics;

        public string Lyrics
        {
            get { return lyrics; }
            set { lyrics = value; }
        }

    }
}
