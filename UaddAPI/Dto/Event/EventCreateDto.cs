﻿using System.ComponentModel.DataAnnotations;

namespace UaddAPI.Dto.Event
{
    public class EventCreateDto
    {
        [Required, MaxLength(150)]
        public string Title { get; set; } = null!;

        [MaxLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(200)]
        public string Location { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;
    }
}