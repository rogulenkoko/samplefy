namespace Samplefy.Tools;

public static class SongProvider
{
    public static List<Song> GetSongs()
    {
        return new List<Song>
        {
            new Song
            {
                Id = Guid.NewGuid(),
                Name = "Sir Duke",
                Author = "Stevie Wonder",
            },
            new Song
            {
                Id = Guid.NewGuid(),
                Name = "Ryd",
                Author = "Steve Lacy",
            },
            new Song
            {
                Id = Guid.NewGuid(),
                Name = "Knock Knock",
                Author = "Matt Martians",
            },
        };
    }
}