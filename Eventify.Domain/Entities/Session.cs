﻿using Eventify.Domain.Attributes;
using Eventify.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Domain.Entities
{
    public class Session : BaseEntity
    {
        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "The StartTime field is required.")]
        [DataType(DataType.DateTime)]
        public required DateTime StartTime { get; set; }

        [Required(ErrorMessage = "The EndTime field is required.")]
        [DataType(DataType.DateTime)]
        [DateGreaterThan("StartTime", ErrorMessage = "End time must be greater than Start time.")]
        public required DateTime EndTime { get; set; }

        [Required(ErrorMessage = "The SpeakerId field is required.")]
        public required Guid SpeakerId { get; set; }

        [Required(ErrorMessage = "The EventId field is required.")]
        public required Guid EventId { get; set; }

        // Navigation properties
        public Speaker Speaker { get; set; }
        public Event Event { get; set; }
        public List<AttendeeFeedback>? Feedback { get; set; } = new List<AttendeeFeedback>();
    }
}