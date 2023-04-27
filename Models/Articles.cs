﻿using System;
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

    public class Articles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Preview { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public Boolean Highlight { get; set; }
        public string MainImageSrc { get; set; }
        public DateTime PublishDate { get; set; }

    }


}

