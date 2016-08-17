using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker.Collections
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
            get { return this.FirstOrDefault(p => p.DotaName.Entity == hero); }
        }

        //TODO: сделать искючение на индексатор
        public DotaHero this[string fullName]
        {
            get { return this.FirstOrDefault(p => p.DotaName.FullName == fullName); }
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
            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Abaddon, "Abaddon"),
                AttackType.Melee, HeroCharacteristic.Strength, 
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AcidSpray, "Acid Spray")),
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Alchemist, "Alchemist"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.AncientApparition, "Ancient Apparition"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.AntiMage, "Anti-Mage"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ArcWarden, "Arc Warden"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Axe, "Axe"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Jungler }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Bane, "Bane"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Batrider, "Batrider"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Jungler }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Beastmaster, "Beastmaster"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Bloodseeker, "Bloodseeker"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Initiator, HeroRole.Jungler, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.BountyHunter, "Bounty Hunter"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Escape, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Brewmaster, "Brewmaster"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Bristleback, "Bristleback"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Broodmother, "Broodmother"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.CentaurWarrunner, "Centaur Warrunner"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ChaosKnight, "Chaos Knight"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Chen, "Chen"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Jungler, HeroRole.Pusher, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Clinkz, "Clinkz"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Clockwerk, "Clockwerk"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.CrystalMaiden, "Crystal Maiden"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Jungler, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.DarkSeer, "Dark Seer"), 
                AttackType.Melee, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Jungler }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Dazzle, "Dazzle"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.DeathProphet, "Death Prophet"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Disruptor, "Disruptor"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Doom, "Doom"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.DragonKnight, "Dragon Knight"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.DrowRanger, "Drow Ranger"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.EarthSpirit, "Earth Spirit"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Earthshaker, "Earthshaker"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ElderTitan, "Elder Titan"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.EmberSpirit, "Ember Spirit"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Enchantress, "Enchantress"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Jungler, HeroRole.Pusher, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Enigma, "Enigma"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Jungler, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.FacelessVoid, "Faceless Void"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Gyrocopter, "Gyrocopter"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Huskar, "Huskar"), 
                AttackType.Ranged, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Initiator }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Invoker, "Invoker"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Io, "Io"), 
                AttackType.Ranged, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Escape, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Jakiro, "Jakiro"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Juggernaut, "Juggernaut"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.KeeperOfTheLight, "Keeper of the Light"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Jungler, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Kunkka, "Kunkka"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.LegionCommander, "Legion Commander"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Leshrac, "Leshrac"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Lich, "Lich"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Lifestealer, "Lifestealer"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Jungler }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Lina, "Lina"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Lion, "Lion"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.LoneDruid, "Lone Druid"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Jungler, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Luna, "Luna"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Lycan, "Lycan"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Escape, HeroRole.Jungler, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Magnus, "Magnus"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Medusa, "Medusa"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Meepo, "Meepo"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Mirana, "Mirana"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Morphling, "Morphling"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.NagaSiren, "Naga Siren"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Pusher, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.NatureProphet, "Nature's Prophet"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Jungler, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Necrophos, "Necrophos"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.NightStalker, "Night Stalker"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.NyxAssassin, "Nyx Assassin"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.OgreMagi, "Ogre Magi"), 
                AttackType.Melee, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Omniknight, "Omniknight"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Durable, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Oracle, "Oracle"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.OutworldDevourer, "Outworld Devourer"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.PhantomAssassin, "Phantom Assassin"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.PhantomLancer, "Phantom Lancer"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Phoenix, "Phoenix"), 
                AttackType.Ranged, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Puck, "Puck"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Pudge, "Pudge"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Pugna, "Pugna"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.QueenOfPain, "Queen of Pain"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Razor, "Razor"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Riki, "Riki"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Rubick, "Rubick"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.SandKing, "Sand King"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Jungler, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ShadowDemon, "Shadow Demon"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ShadowFiend, "Shadow Fiend"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ShadowShaman, "Shadow Shaman"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Silencer, "Silencer"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.SkywrathMage, "Skywrath Mage"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Slardar, "Slardar"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Slark, "Slark"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Sniper, "Sniper"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Spectre, "Spectre"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Escape }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.SpiritBreaker, "Spirit Breaker"),
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.StormSpirit, "Storm Spirit"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Sven, "Sven"), 
                AttackType.Melee, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Techies, "Techies"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.TemplarAssassin, "Templar Assassin"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Terrorblade, "Terrorblade"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Tidehunter, "Tidehunter"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Timbersaw, "Timbersaw"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Durable, HeroRole.Escape, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Tinker, "Tinker"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Tiny, "Tiny"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.TreantProtector, "Treant Protector"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.TrollWarlord, "Troll Warlord"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Pusher }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Tusk, "Tusk"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Undying, "Undying"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Ursa, "Ursa"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Jungler }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.VengefulSpirit, "Vengeful Spirit"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Venomancer, "Venomancer"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Viper, "Viper"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Visage, "Visage"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Warlock, "Warlock"), 
                AttackType.Ranged, 
                HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Durable, HeroRole.Initiator, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Weaver, "Weaver"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Windranger, "Windranger"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.WinterWyvern, "Winter Wyvern"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.WitchDoctor, "Witch Doctor"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.WraithKing, "Wraith King"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Support }
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Zeus, "Zeus"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Nuker }
            }));
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
