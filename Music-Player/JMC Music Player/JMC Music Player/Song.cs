using CsvHelper.Configuration.Attributes;
using System;
using System.IO;

/// <summary>
/// Author: Andrew Williamson
/// 
/// </summary>
namespace Music_Player
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
        [Index(0)]
        [Name("title")]
        public string Title { get; set; }

        /// <summary>
        /// The file path of the song.
        /// Second column in csv file with column header "filePath"
        /// </summary>
        [Index(1)]
        [Name("filePath")]
        public string FilePath { get; set; }

        /// <summary>
        /// Constructor to add a song using only file path.
        /// </summary>
        /// <param name="filePath">The path to the song.</param>
        public Song(string filePath)
        {
            FilePath = filePath;
            Title = Path.GetFileNameWithoutExtension(filePath);
        }

        public int CompareTo(Song other) => Title.CompareTo(other.Title);
    }
}
