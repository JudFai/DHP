using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EFDota.Types
{
    public class MatchDetail
    {
        #region Properties

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Key, Column(Order = 1)]
        public long MatchSeqNum { get; set; }

        ///// <summary>
        ///// Длительность матча, сек.
        ///// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Длительность с момента начала подключения всех игроков
        /// </summary>
        public int PreGameDuration { get; set; }

        /// <summary>
        /// Кол-во секунд прошедших с 01.01.1970
        /// </summary>
        public long StartTime { get; set; }

        public Faction Winner { get; set; }

        public GameMode GameMode { get; set; }

        public int FirstBloodTime { get; set; }

        public LobbyType LobbyType { get; set; }

        public int HumanPlayers { get; set; }

        public List<MatchPlayer> MatchPlayers { get; set; }

        public long LeagueID { get; set; }

        public int RadiantScore { get; set; }
        public int DireScore { get; set; }

        public TowerStatus TowerStatusRadiant { get; set; }
        public TowerStatus TowerStatusDire { get; set; }
        public BarracksStatus BarracksStatusRadiant { get; set; }
        public BarracksStatus BarracksStatusDire { get; set; }

        //public List<PickOrBan> PickOrBans { get; set; }

        public int? RadiantTeamID { get; set; }
        public string RadiantName { get; set; }
        /// <summary>
        /// Идентификатор до логотипа
        /// </summary>
        public long? RadiantLogo { get; set; }
        /// <summary>
        /// В полном ли составе команда в этом матче
        /// </summary>
        public bool? RadiantTeamComplete { get; set; }

        public int? DireTeamID { get; set; }
        public string DireName { get; set; }
        /// <summary>
        /// Идентификатор до логотипа
        /// </summary>
        public long? DireLogo { get; set; }
        /// <summary>
        /// В полном ли составе команда в этом матче
        /// </summary>
        public bool? DireTeamComplete { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("MatchID: {0}", ID);
        }

        #endregion
    }
}
