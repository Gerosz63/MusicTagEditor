using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagEditor
{
    internal class Album
    {
        private string _album;
        public string album { get { return _album; } }
        public void SetAlbum(string albumname, bool forced = false)
        {
            if (forced)
                _album = albumname;
            else
            {
                if (Albums.Any(x => x.ToLower() == albumname.ToLower()))
                    throw new SameValueException();
                else if (Albums.Any(x => x.ToLower().Contains(albumname.ToLower())))
                    throw new SimilarValueException();
                else
                {
                    Albums.Add(albumname);
                    _album = albumname;
                }
            }
        }
        static public List<string> Albums = new List<string>();
    }
}
