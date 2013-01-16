using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AutoCompleteTextBox.Models
{
    public class AutoData:DbContext
    {
        DbSet<NewAdmin> newAdmin { get; set; }
        DbSet<InfoBook> infoBook { get; set; }
        DbSet<BookImage> bookImage { get; set; }
    }
}