﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class ContractStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
       
    }
}
