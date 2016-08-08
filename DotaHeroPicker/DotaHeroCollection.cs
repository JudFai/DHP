using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    public class DotaHeroCollection : ReadOnlyCollection<DotaHero>
    {
        #region Fields

        private static readonly object _locker = new object();
        private static DotaHeroCollection _instance;

        #endregion

        #region Indexers

        //TODO: сделать искючение на индексатор
        public DotaHero this[Hero hero]
        {
            get { return this.FirstOrDefault(p => p.Name.Hero == hero); }
        }

        //TODO: сделать искючение на индексатор
        public DotaHero this[string fullName]
        {
            get { return this.FirstOrDefault(p => p.Name.FullName == fullName); }
        }


        //TODO: сделать искючение на индексатор 
        public new DotaHero this[int index]
        {
            get { return base[index]; }
        }

        #endregion

        #region Constructors

        private DotaHeroCollection()
            : base(new List<DotaHero>())
        {
            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Abaddon, "Abaddon"),
                AttackType.Melee, HeroCharacteristic.Strength, 
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Alchemist, "Alchemist"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.AncientApparition, "Ancient Apparition"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.AntiMage, "Anti-Mage"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.ArcWarden, "Arc Warden"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Axe, "Axe"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Jungler }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Bane, "Bane"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Batrider, "Batrider"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Jungler }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Beastmaster, "Beastmaster"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Bloodseeker, "Bloodseeker"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Initiator, HeroRole.Jungler, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.BountyHunter, "Bounty Hunter"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Escape, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Brewmaster, "Brewmaster"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Bristleback, "Bristleback"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Broodmother, "Broodmother"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.CentaurWarrunner, "Centaur Warrunner"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.ChaosKnight, "Chaos Knight"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Chen, "Chen"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Jungler, HeroRole.Pusher, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Clinkz, "Clinkz"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Clockwerk, "Clockwerk"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.CrystalMaiden, "Crystal Maiden"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Jungler, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.DarkSeer, "Dark Seer"), 
                AttackType.Melee, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Jungler }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Dazzle, "Dazzle"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.DeathProphet, "Death Prophet"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Disruptor, "Disruptor"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Doom, "Doom"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.DragonKnight, "Dragon Knight"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.DrowRanger, "Drow Ranger"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.EarthSpirit, "Earth Spirit"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Earthshaker, "Earthshaker"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.ElderTitan, "Elder Titan"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.EmberSpirit, "Ember Spirit"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Enchantress, "Enchantress"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Jungler, HeroRole.Pusher, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Enigma, "Enigma"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Jungler, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.FacelessVoid, "Faceless Void"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Gyrocopter, "Gyrocopter"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Huskar, "Huskar"), 
                AttackType.Ranged, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Initiator }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Invoker, "Invoker"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Io, "Io"), 
                AttackType.Ranged, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Escape, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Jakiro, "Jakiro"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Juggernaut, "Juggernaut"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.KeeperOfTheLight, "Keeper of the Light"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Jungler, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Kunkka, "Kunkka"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.LegionCommander, "Legion Commander"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Leshrac, "Leshrac"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Lich, "Lich"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Lifestealer, "Lifestealer"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Jungler }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Lina, "Lina"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Lion, "Lion"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.LoneDruid, "Lone Druid"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Jungler, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Luna, "Luna"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Lycan, "Lycan"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Escape, HeroRole.Jungler, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Magnus, "Magnus"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Medusa, "Medusa"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Meepo, "Meepo"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Mirana, "Mirana"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Morphling, "Morphling"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.NagaSiren, "Naga Siren"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Pusher, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.NatureProphet, "Nature's Prophet"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Jungler, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Necrophos, "Necrophos"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.NightStalker, "Night Stalker"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.NyxAssassin, "Nyx Assassin"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.OgreMagi, "Ogre Magi"), 
                AttackType.Melee, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Omniknight, "Omniknight"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Durable, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Oracle, "Oracle"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.OutworldDevourer, "Outworld Devourer"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.PhantomAssassin, "Phantom Assassin"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.PhantomLancer, "Phantom Lancer"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Phoenix, "Phoenix"), 
                AttackType.Ranged, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Puck, "Puck"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Pudge, "Pudge"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Pugna, "Pugna"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.QueenOfPain, "Queen of Pain"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Razor, "Razor"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Riki, "Riki"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Rubick, "Rubick"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.SandKing, "Sand King"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Jungler, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.ShadowDemon, "Shadow Demon"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.ShadowFiend, "Shadow Fiend"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.ShadowShaman, "Shadow Shaman"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Silencer, "Silencer"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.SkywrathMage, "Skywrath Mage"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Slardar, "Slardar"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Slark, "Slark"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Sniper, "Sniper"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Spectre, "Spectre"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Escape }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.SpiritBreaker, "Spirit Breaker"),
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.StormSpirit, "Storm Spirit"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Sven, "Sven"), 
                AttackType.Melee, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Techies, "Techies"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.TemplarAssassin, "Templar Assassin"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Terrorblade, "Terrorblade"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Tidehunter, "Tidehunter"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Timbersaw, "Timbersaw"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Durable, HeroRole.Escape, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Tinker, "Tinker"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Tiny, "Tiny"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.TreantProtector, "Treant Protector"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.TrollWarlord, "Troll Warlord"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Pusher }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Tusk, "Tusk"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Undying, "Undying"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Ursa, "Ursa"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Jungler }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.VengefulSpirit, "Vengeful Spirit"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Venomancer, "Venomancer"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Viper, "Viper"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Visage, "Visage"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Warlock, "Warlock"), 
                AttackType.Ranged, 
                HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Durable, HeroRole.Initiator, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Weaver, "Weaver"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Windranger, "Windranger"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.WinterWyvern, "Winter Wyvern"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.WitchDoctor, "Witch Doctor"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.WraithKing, "Wraith King"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Support }));

            Items.Add(DotaHero.Factory.CreateDotaHero(
                new HeroName(Hero.Zeus, "Zeus"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Nuker }));
        }

        #endregion

        #region Public Methods

        public static DotaHeroCollection GetInstance()
        {
            lock (_locker)
            {
                return _instance ?? (_instance = new DotaHeroCollection());
            }
        }

        #endregion
    }
}
