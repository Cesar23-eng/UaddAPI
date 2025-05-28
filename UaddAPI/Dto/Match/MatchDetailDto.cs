using System;

namespace UaddAPI.Dto.NewPost
{
    public class MatchDetailDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string TeamA { get; set; } = null!;

        public string DescriptionA { get; set; } = null!;

        public string TeamB { get; set; } = null!;

        public string DescriptionB { get; set; } = null!;

        public DateTime MatchDate { get; set; }

        public string Location { get; set; } = null!;

        public string SportType { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int CreatedByUserId { get; set; }
    }
}