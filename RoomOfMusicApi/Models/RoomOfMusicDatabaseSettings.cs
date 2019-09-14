using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomOfMusicApi.Models
{
    public class RoomOfMusicDatabaseSettings : IRoomOfMusicDatabaseSettings
    {
        public string StudentsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IRoomOfMusicDatabaseSettings
    {
        string StudentsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
