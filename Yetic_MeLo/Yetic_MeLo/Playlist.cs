using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yetic_MeLo
{
    class Playlist
    {
        ArrayList Songs;

        public Playlist(string[] Songs)
        {
            this.Songs = new ArrayList(Songs);
        }

        public Playlist(ArrayList Songs)
        {
            this.Songs = Songs;
        }

        public void RemoveSong(string SongToRemove)
        {
            //removes all occurences
            foreach (string song in Songs)
            {
                if (song.Equals(SongToRemove))
                {
                    Songs.Remove(song);
                    break; //- if there is no chance for duplicates
                }
            }
        }

        //returns true if the add was successful otherwise the song was already on the playlist
        public Boolean AddSong(string SongToAdd)
        {
            if (Songs.Contains(SongToAdd)) return false;
            Songs.Add(SongToAdd);
            return true;
        }

    }
}
