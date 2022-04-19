using CsvHelper.Configuration.Attributes;
using System;
using System.IO;

/// <summary>
/// Author: Andrew Williamson
/// 
/// </summary>
namespace JMC_Music_Player
{
    /// <summary>
    /// This class contains the song's details and is used by the 3rd party library 
    /// CsvHelper
    /// </summary>
    class Song : IComparable<Song>
    {
        /// <summary>
        /// The title of the song.
        /// First column in csv file with column header "title"
        /// </summary>
        //[Name("title")]
        [Index(0)]
        public string Title { get; set; }

        /// <summary>
        /// The file path of the song.
        /// Second column in csv file with column header "filePath"
        /// </summary>
        //[Name("filePath")]
        [Index(1)]
        public string FilePath { get; set; }

        /// <summary>
        /// Constructor to add a song using only file path.
        /// </summary>
        /// <param name="FilePath">The path to the song.</param>
        public Song(string FilePath)
        {
            this.FilePath = FilePath;
            Title = System.IO.Path.GetFileNameWithoutExtension(FilePath);
        }

        public int CompareTo(Song other) => Title.CompareTo(other.Title);
    }
}
