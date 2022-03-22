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
        /// <summary>Id property to identify the object within this application</summary>
        public Guid Id { get; set; }
        
        /// <summary>Property holding the name of the object</summary>
        public string Name { get; set; }
        
        /// <summary>Property holding a description of the object</summary>
        public string Description { get; set; }
    }
}
