using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Domain.Pessoas
{
    public class Pessoa : Entity<Guid>
    {
        public override Guid Id { get; set; }
    }
}
