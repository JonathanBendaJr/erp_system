﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MaritalStatusDTO
    {
        public int ID { get; set; }
        public string MaritalStatus { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
    }
}
