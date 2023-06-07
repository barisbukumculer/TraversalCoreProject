﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.AnnouncementDTOs
{
    public class AnnouncementUpdateDTO
    {
        public int AnnouncementID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get;}
    }
}
