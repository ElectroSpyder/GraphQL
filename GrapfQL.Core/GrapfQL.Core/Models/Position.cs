using System;
using System.Collections.Generic;

namespace GrapfQL.Core.Models
{
    public partial class Position
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
