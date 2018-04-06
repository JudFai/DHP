using System;

namespace OpenDota.Types
{
    [Flags]
    public enum TowerStatus : int
    {
        None = 0,
        TopTier1 = 1,
        TopTier2 = 2,
        TopTier3 = 4,
        MiddleTier1 = 8,
        MiddleTier2 = 16,
        MiddleTier3 = 32,
        BottomTier1 = 64,
        BottomTier2 = 128,
        BottomTier3 = 256,
        AncientBottom = 512,
        AncientTop = 1024
    }
}
