using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillTeam.Library.Models
{

    /// <summary>Base class for all models</summary>
    /// <remarks>Basically because im too lazy to include the same properties in lots of class. technically just code reuse!</remarks>
    public class ModelBase
    {
        public Guid Id { get; set; }

    }
}
