/*
4. Song [Algorithmic thinking] [HashSet] [Linked list] 

A playlist is considered a repeating playlist if any of the songs contain a reference to a previous song in the playlist. Otherwise, the playlist will end with the last song which points to null.

Implement a function IsRepeatingPlaylist that, efficiently with respect to time used, returns true if a playlist is repeating or false if it is not.

https://www.testdome.com/d/c-sharp-interview-questions/18

using System;

public class Song
{
    private string name;
    public Song NextSong { get; set; }
 
    public Song(string name)
    {
        this.name = name;
    }
    
    public bool IsRepeatingPlaylist()
    {
        throw new InvalidOperationException("Waiting to be implemented.");
    }
    
    public static void Main(string[] args)
    {
        Song first = new Song("Hello");
        Song second = new Song("Eye of the tiger");
    
        first.NextSong = second;
        second.NextSong = first;
    
        Console.WriteLine(first.IsRepeatingPlaylist());
    }
}
*/

// =============================================================== solution (passes 4/4 tests)

using System;
using System.Collections.Generic;

public class Song
{
    private string name;
    public Song NextSong { get; set; }
 
    public Song(string name)
    {
        this.name = name;
    }
    
    public bool IsRepeatingPlaylist()
    {
        bool result = false;
        var songs = new HashSet<String>(){this.name};
        Song currentSong = this;
        while(currentSong.NextSong != null)
        {
            if(songs.Contains(currentSong.NextSong.name)){
                result = true;
                break;
            } else {
                songs.Add(currentSong.NextSong.name);
                currentSong = currentSong.NextSong;
            }
        }
        return result;
    }
    
    public static void Main(string[] args)
    {
        Song first = new Song("Hello");
        Song second = new Song("Eye of the tiger");
    
        first.NextSong = second;
        second.NextSong = first;
    
        Console.WriteLine(first.IsRepeatingPlaylist());
    }
}