using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota.Types
{
    public class PickOrBan
    {
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public bool IsPick { get; set; }

        public Hero Hero { get; set; }

        public Faction Team { get; set; }

        public int Order { get; set; }

        public MatchDetail MatchDetail { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0}: {1}", (IsPick ? "Pick" : "Ban"), Hero);
        }

        #endregion
    }
}
