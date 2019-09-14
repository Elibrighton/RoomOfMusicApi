using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RoomOfMusicApi.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [JsonProperty("Surname")]
        public string LastName { get; set; }
        [DefaultValue(false)]
        public bool IsRetired { get; set; }
        public string ParentName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Instrument { get; set; }
        public int Grade { get; set; }
        [JsonProperty("DateOfBirth")]
        public DateTime Dob { get; set; }
    }
}