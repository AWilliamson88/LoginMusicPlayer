using System;
using System.Collections.Generic;
using System.Linq;
namespace Music_Player
{
    class BinarySearch
    {
        public int Search(LinkedList<Song> songData, String songToFind)
        {
            Song[] songArray = songData.ToArray();
            int min = 0;
            int max = songData.Count() - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (songArray[mid].Title.CompareTo(songToFind) < 0)
                {
                    min = mid + 1;
                }
                else if (songArray[mid].Title.CompareTo(songToFind) > 0)
                {
                    max = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }

    }
}
