﻿using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class StoryDto
    {
        public Guid Id { get; set; }

        public int TableId { get; set; }

        public string Name { get; set; }
        
    }
}