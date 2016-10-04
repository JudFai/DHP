using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota.Types
{
    public class AbilityUpgrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        // TODO: на перспективу сделать enum
        public int Ability { get; set; }

        /// <summary>
        /// Уровень на котором была изучена способность
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Время на которое была изучена способность
        /// </summary>
        public int Time { get; set; }

        public MatchPlayer MatchPlayer { get; set; }
    }
}
