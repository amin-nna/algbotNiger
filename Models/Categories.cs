using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace algbotNiger.Models
{

    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    


}

