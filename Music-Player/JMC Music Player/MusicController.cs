using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;

/// <summary>
/// Author: Andrew Williamson
/// 
/// </summary>
namespace JMC_Music_Player
{
    /// <summary>
    /// This class is responsible for controlling the music player.
    /// </summary>
    class MusicController
    {
        private LinkedList<Song> songs;
        private Song currentSong;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;

        public MusicController(AxWMPLib.AxWindowsMediaPlayer player)
        {
            mediaPlayer = player;
            songs = new LinkedList<Song>();
        }

        /// <summary>
        /// Adds a song to the list if it's not a duplicate
        /// </summary>
        /// <param name="source">The file path to the song.</param>
        public void Add(string source)
        {
            if (CheckForDuplicates(source))
                songs.AddLast(new Song(source));
        }

        /// <summary>
        /// Adds the song to the list.
        /// Used by the 3rd party library "CsvHelper".
        /// </summary>
        /// <param name="song">The song to add.</param>
        public void Add(Song song)
        {
            songs.AddLast(song);
        }

        /// <summary>
        /// The current Song.
        /// </summary>
        /// <returns>The current Song.</returns>
        public Song CurrentSong()
        {
            return currentSong;
        }

        /// <summary>
        /// Check if the song already exists in the list by using the song name not the path. 
        /// This prevents duplicates from different folders.
        /// </summary>
        /// <param name="newSongPath">The path for the song to be checked.</param>
        /// <returns>True if the song should be added to the list, otherwise false.</returns>
        private bool CheckForDuplicates(string newSongPath)
        {
            string newSongTitle = Path.GetFileNameWithoutExtension(newSongPath);

            foreach (Song s in songs)
            {
                if (s.Title.Equals(newSongTitle))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// This method plays the song if it's not playing or pauses it if it is.
        /// </summary>
        public void PlayPause()
        {
            if (currentSong == null)
            {
                if (songs.Count() > 0)
                {
                    currentSong = songs.First();
                    mediaPlayer.URL = currentSong.FilePath;
                    mediaPlayer.Ctlcontrols.play();
                }
            }
            else if (mediaPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                mediaPlayer.Ctlcontrols.pause();
            }
            else
            {
                mediaPlayer.Ctlcontrols.play();
            }

        }

        /// <summary>
        /// This method stops the music player from playing.
        /// </summary>
        public void Stop()
        {
            mediaPlayer.Ctlcontrols.stop();
        }

        /// <summary>
        /// This method skips the current song and plays the next one in the list.
        /// If the song is the last one in the list then the first song is played.
        /// </summary>
        public void Next()
        {
            mediaPlayer.Ctlcontrols.stop();
            if (songs.Find(currentSong).Next != null)
            {
                currentSong = songs.Find(currentSong).Next.Value;
            }
            else
            {
                currentSong = songs.First();
            }
            mediaPlayer.URL = currentSong.FilePath;
        }

        /// <summary>
        /// This method skips back to the previous song in the list.
        /// If the song is the first one in the list then the last song is played.
        /// </summary>
        public void Previous()
        {
            mediaPlayer.Ctlcontrols.stop();
            if (songs.Find(currentSong).Previous != null)
            {
                currentSong = songs.Find(currentSong).Previous.Value;
            }
            else
            {
                currentSong = songs.Last();
            }
            mediaPlayer.URL = currentSong.FilePath;
        }

        /// <summary>
        /// This method usees an instance of the BinarySearch class to get the index for
        /// the song to find in the song list. 
        /// If the song is found it is played, otherwise an error message is displayed.
        /// </summary>
        /// <param name="songToFind">The title of the song to find.</param>
        public void SearchForSong(String songToFind)
        {
            BinarySearch bs = new BinarySearch();
            int index = bs.Search(GetSongList(), songToFind);

            if (index >= 0)
            {
                currentSong = songs.ElementAt(index);
                mediaPlayer.URL = currentSong.FilePath;
            }
            else
            {
                MessageBox.Show(
                    "No song by that name was found.\n" +
                    "Please enter a different name and try again.",
                    "Not Found",
                    MessageBoxButtons.OK
                );
            }
        }

        /// <summary>
        /// This method creates the merge sorter object and uses it to sort 
        /// the song list.
        /// Called every time a song is added to the list.
        /// </summary>
        public void SortList()
        {
            MergeSorter ms = new MergeSorter();
            SetSongList(ms.Sort(songs));
        }

        public LinkedList<Song> GetSongList()
        {
            return songs;
        }

        private void SetSongList(LinkedList<Song> newList)
        {
            songs = newList;
        }

        public void ClearSongList()
        {
            songs.Clear();
        }
    }
}
