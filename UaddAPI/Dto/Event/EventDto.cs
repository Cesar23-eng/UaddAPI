using System;

namespace UaddAPI.Dto.Event
{
    public class EventDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Location { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}