using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker.Collections
{
    public class DotaItemCollection : ReadOnlyCollection<DotaItem>
    {
        #region Fields

        private static readonly object _locker = new object();
        private static DotaItemCollection _instance;

        #endregion

        #region Indexers

        public DotaItem this[Item item]
        {
            get { return this.FirstOrDefault(p => p.DotaName.Entity == item); }
        }

        #endregion

        #region Constructors

        private DotaItemCollection()
            : base(new List<DotaItem>())
        {
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.AbyssalBlade, "Abyssal Blade")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.AegisImmortal, "Aegis of the Immortal")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.AetherLens, "Aether Lens")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.AghanimScepter, "Aghanim's Scepter")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.AnimalCourier, "Animal Courier")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.ArcaneBoots, "Arcane Boots")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.ArmletMordiggian, "Armlet of Mordiggian")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.AssaultCuirass, "Assault Cuirass")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BandElvenskin, "Band of Elvenskin")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BattleFury, "Battle Fury")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BeltStrength, "Belt of Strength")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BlackKingBar, "Black King Bar")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BladeMail, "Blade Mail")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BladeAlacrity, "Blade of Alacrity")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BladesAttack, "Blades of Attack")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BlightStone, "Blight Stone")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BlinkDagger, "Blink Dagger")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Bloodstone, "Bloodstone")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Bloodthorn, "Bloodthorn")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BootsSpeed, "Boots of Speed")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BootsTravel1, "Boots of Travel")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.BootsTravel2, "Boots of Travel")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Bottle, "Bottle")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Bracer, "Bracer")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Broadsword, "Broadsword")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Buckler, "Buckler")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Butterfly, "Butterfly")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Chainmail, "Chainmail")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Cheese, "Cheese")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Circlet, "Circlet")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Clarity, "Clarity")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Claymore, "Claymore")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Cloak, "Cloak")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.CrimsonGuard, "Crimson Guard")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Crystalys, "Crystalys")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Daedalus, "Daedalus")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Dagon1, "Dagon")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Dagon2, "Dagon (level 2)")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Dagon3, "Dagon (level 3)")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Dagon4, "Dagon (level 4)")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Dagon5, "Dagon (level 5)")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.DemonEdge, "Demon Edge")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Desolator, "Desolator")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.DiffusalBlade1, "Diffusal Blade")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.DiffusalBlade2, "Diffusal Blade (level 2)")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.DivineRapier, "Divine Rapier")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.DragonLance, "Dragon Lance")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.DrumEndurance, "Drum of Endurance")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.DustAppearance, "Dust of Appearance")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Eaglesong, "Eaglesong")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.EchoSabre, "Echo Sabre")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.EnchantedMango, "Enchanted Mango")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.EnergyBooster, "Energy Booster")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.EtherealBlade, "Ethereal Blade")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.EulScepterDivinity, "Eul's Scepter of Divinity")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.EyeSkadi, "Eye of Skadi")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.FaerieFire, "Faerie Fire")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.FlyingCourier, "Flying Courier")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.ForceStaff, "Force Staff")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.GauntletsStrength, "Gauntlets of Strength")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.GemTrueSight, "Gem of True Sight")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.GhostScepter, "Ghost Scepter")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.GlimmerCape, "Glimmer Cape")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.GlovesHaste, "Gloves of Haste")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.GuardianGreaves, "Guardian Greaves")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.HandMidas, "Hand of Midas")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Headdress, "Headdress")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.HealingSalve, "Healing Salve")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.HeartTarrasque, "Heart of Tarrasque")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.HeavenHalberd, "Heaven's Halberd")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.HelmIronWill, "Helm of Iron Will")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.HelmDominator, "Helm of the Dominator")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.HoodDefiance, "Hood of Defiance")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.HurricanePike, "Hurricane Pike")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Hyperstone, "Hyperstone")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.InfusedRaindrop, "Infused Raindrop")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.IronBranch, "Iron Branch")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.IronTalon, "Iron Talon")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Javelin, "Javelin")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.LinkenSphere, "Linken's Sphere")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.LotusOrb, "Lotus Orb")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Maelstrom, "Maelstrom")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.MagicStick, "Magic Stick")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.MagicWand, "Magic Wand")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.MantaStyle, "Manta Style")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.MantleIntelligence, "Mantle of Intelligence")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.MaskMadness, "Mask of Madness")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.MedallionCourage, "Medallion of Courage")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Mekansm, "Mekansm")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.MithrilHammer, "Mithril Hammer")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Mjollnir, "Mjollnir")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.MonkeyKingBar, "Monkey King Bar")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.MoonShard, "Moon Shard")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.MorbidMask, "Morbid Mask")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.MysticStaff, "Mystic Staff")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Necronomicon1, "Necronomicon")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Necronomicon2, "Necronomicon (level 2)")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Necronomicon3, "Necronomicon (level 3)")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.NullTalisman, "Null Talisman")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.OblivionStaff, "Oblivion Staff")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.ObserverandSentryWards, "Observer and Sentry Wards")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.ObserverWard, "Observer Ward")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.OctarineCore, "Octarine Core")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.OgreClub, "Ogre Club")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.OrbVenom, "Orb of Venom")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.OrchidMalevolence, "Orchid Malevolence")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Perseverance, "Perseverance")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.PhaseBoots, "Phase Boots")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.PipeInsight, "Pipe of Insight")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Platemail, "Platemail")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.PointBooster, "Point Booster")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.PoorManShield, "Poor Man's Shield")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.PowerTreads, "Power Treads")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Quarterstaff, "Quarterstaff")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.QuellingBlade, "Quelling Blade")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Radiance, "Radiance")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Reaver, "Reaver")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.RefresherOrb, "Refresher Orb")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.RingAquila, "Ring of Aquila")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.RingBasilius, "Ring of Basilius")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.RingHealth, "Ring of Health")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.RingProtection, "Ring of Protection")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.RingRegen, "Ring of Regen")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.RobeMagi, "Robe of the Magi")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.RodAtos, "Rod of Atos")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.SacredRelic, "Sacred Relic")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.SageMask, "Sage's Mask")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Sange, "Sange")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.SangeandYasha, "Sange and Yasha")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Satanic, "Satanic")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.ScytheVyse, "Scythe of Vyse")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.SentryWard, "Sentry Ward")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.ShadowAmulet, "Shadow Amulet")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.ShadowBlade, "Shadow Blade")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.ShivaGuard, "Shiva's Guard")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.SilverEdge, "Silver Edge")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.SkullBasher, "Skull Basher")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.SlippersAgility, "Slippers of Agility")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.SmokeDeceit, "Smoke of Deceit")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.SolarCrest, "Solar Crest")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.SoulBooster, "Soul Booster")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.SoulRing, "Soul Ring")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.StaffWizardry, "Staff of Wizardry")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.StoutShield, "Stout Shield")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.TalismanEvasion, "Talisman of Evasion")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Tango, "Tango")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.TangoShared, "Tango (Shared)")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.TomeKnowledge, "Tome of Knowledge")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.TownPortalScroll, "Town Portal Scroll")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.TranquilBoots, "Tranquil Boots")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.UltimateOrb, "Ultimate Orb")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.UrnShadows, "Urn of Shadows")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Vanguard, "Vanguard")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.VeilDiscord, "Veil of Discord")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.VitalityBooster, "Vitality Booster")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.VladmirOffering, "Vladmir's Offering")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.VoidStone, "Void Stone")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.WindLace, "Wind Lace")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.WraithBand, "Wraith Band")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.Yasha, "Yasha")));
            Items.Add(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.RiverVialChrome, "River Vial: Chrome")));
        }

        #endregion

        #region Public Methods

        public static DotaItemCollection GetInstance()
        {
            lock (_locker)
            {
                return _instance ?? (_instance = new DotaItemCollection());
            }
        }

        #endregion
    }
}
