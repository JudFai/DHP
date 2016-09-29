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
        public int StartTime { get; set; }

        public Faction Winner { get; set; }

        public GameMode GameMode { get; set; }

        public int FirstBloodTime { get; set; }

        public LobbyType LobbyType { get; set; }

        public int HumanPlayers { get; set; }

        public List<Player> Players { get; set; }

        public long LeagueID { get; set; }

        public int RadiantScore { get; set; }
        public int DireScore { get; set; }

        // TODO: На перспективу сделать статусы
        public int TowerStatusRadiant { get; set; }
        public int TowerStatusDire { get; set; }

        // TODO: На перспективу сделать статусы
        public int BarracksStatusRadiant { get; set; }
        public int BarracksStatusDire { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("MatchID: {0}", ID);
        }

        #endregion
    }
}
