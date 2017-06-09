namespace DotaHeroPicker.ServerLog
{
    class DotaPlayer : IDotaPlayer
    {
        #region Constructors

        public DotaPlayer(ulong id, int slot)
        {
            ID = id;
            Slot = slot;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("Slot: {0}, ID: {1}", Slot, ID);
        }

        #endregion

        #region IDotaPLayer Members

        public int Slot { get; private set; }
        public ulong ID { get; private set; }

        #endregion
    }
}