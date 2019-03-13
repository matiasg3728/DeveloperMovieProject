using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Chromebook_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Chromebook_Manager.Data
{
    public class ChromebookManagementContext : DbContext
    {
        public ChromebookManagementContext(DbContextOptions<ChromebookManagementContext> options) : base(options)
        {
            //What can we use this for??????
        }

        //"A DBset typically(what does that mean) corresponds to a table, an entity corresponds to a row" from the tutorial
        public DbSet<Chromebook> Chromebooks { get; set; }

    }
}
