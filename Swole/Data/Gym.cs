﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swole.Data
{
    public class Gym
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public IEnumerable<Member> Members { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}