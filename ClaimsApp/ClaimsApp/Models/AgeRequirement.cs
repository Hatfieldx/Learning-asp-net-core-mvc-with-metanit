﻿using System;
using Microsoft.AspNetCore.Authorization;

namespace ClaimsApp.Models
{
    public class AgeRequirement : IAuthorizationRequirement
    {
        protected internal int Age { get; set; }
        public AgeRequirement(int age)
        {
            Age = age;
        }
    }
}
