using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetiMeLo
{
    class Playlist
    {
        public ArrayList Songs;
        public string PlaylistName;

        public Playlist(string[] Songs, string PlaylistName)
        {
            this.Songs = new ArrayList(Songs);
            this.PlaylistName = PlaylistName;
        }

        public Playlist(ArrayList Songs, string PlaylistName)
        {
            this.Songs = Songs;
            this.PlaylistName = PlaylistName;
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
