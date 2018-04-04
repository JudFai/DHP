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
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AphoticShield, "Aphotic Shield")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BorrowedTime, "Borrowed Time")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CurseAvernus, "Curse of Avernus")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MistCoil, "Mist Coil"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Alchemist, "Alchemist"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AcidSpray, "Acid Spray")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ChemicalRage, "Chemical Rage")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GreevilGreed, "Greevil's Greed")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.UnstableConcoction, "Unstable Concoction")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.UnstableConcoctionThrow, "Unstable Concoction Throw"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.AncientApparition, "Ancient Apparition"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ChillingTouch, "Chilling Touch")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ColdFeet, "Cold Feet")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IceBlast, "Ice Blast")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IceVortex, "Ice Vortex")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Release, "Release"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.AntiMage, "Anti-Mage"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BlinkAntiMage, "Blink")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ManaBreak, "Mana Break")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ManaVoid, "Mana Void")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SpellShield, "Spell Shield"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ArcWarden, "Arc Warden"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Flux, "Flux")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MagneticField, "Magnetic Field")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SparkWraith, "Spark Wraith")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TempestDouble, "Tempest Double"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Axe, "Axe"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Jungler },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BattleHunger, "Battle Hunger")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BerserkerCall, "Berserker's Call")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CounterHelix, "Counter Helix")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CullingBlade, "Culling Blade"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Bane, "Bane"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BrainSap, "Brain Sap")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Enfeeble, "Enfeeble")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FiendGrip, "Fiend's Grip")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Nightmare, "Nightmare")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.NightmareEnd, "Nightmare End"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Batrider, "Batrider"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Jungler },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Firefly, "Firefly")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Flamebreak, "Flamebreak")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FlamingLasso, "Flaming Lasso")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StickyNapalm, "Sticky Napalm"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Beastmaster, "Beastmaster"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CallWildBoar, "Call of the Wild: Boar")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CallWildHawk, "Call of the Wild: Hawk")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.InnerBeast, "Inner Beast")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PrimalRoar, "Primal Roar")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WildAxes, "Wild Axes"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Bloodseeker, "Bloodseeker"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Initiator, HeroRole.Jungler, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BloodRite, "Blood Rite")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Bloodrage, "Bloodrage")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Rupture, "Rupture")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Thirst, "Thirst"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.BountyHunter, "Bounty Hunter"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Escape, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Jinada, "Jinada")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShadowWalk, "Shadow Walk")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShurikenToss, "Shuriken Toss")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Track, "Track"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Brewmaster, "Brewmaster"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DrunkenBrawler, "Drunken Brawler")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DrunkenHaze, "Drunken Haze")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PrimalSplit, "Primal Split")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ThunderClap, "Thunder Clap"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Bristleback, "Bristleback"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Bristleback, "Bristleback")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.QuillSpray, "Quill Spray")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ViscousNasalGoo, "Viscous Nasal Goo")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Warpath, "Warpath"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Broodmother, "Broodmother"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IncapacitatingBite, "Incapacitating Bite")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.InsatiableHunger, "Insatiable Hunger")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SpawnSpiderlings, "Spawn Spiderlings")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SpinWeb, "Spin Web"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.CentaurWarrunner, "Centaur Warrunner"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DoubleEdge, "Double Edge")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.HoofStomp, "Hoof Stomp")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Return, "Return")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Stampede, "Stampede"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ChaosKnight, "Chaos Knight"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ChaosBolt, "Chaos Bolt")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ChaosStrike, "Chaos Strike")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Phantasm, "Phantasm")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.RealityRift, "Reality Rift"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Chen, "Chen"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Jungler, HeroRole.Pusher, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.HandGod, "Hand of God")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.HolyPersuasion, "Holy Persuasion")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Penitence, "Penitence")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TestFaithDamage, "Test of Faith")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TestFaithTeleport, "Test of Faith"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Clinkz, "Clinkz"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DeathPact, "Death Pact")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SearingArrows, "Searing Arrows")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SkeletonWalk, "Skeleton Walk")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Strafe, "Strafe"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Clockwerk, "Clockwerk"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BatteryAssault, "Battery Assault")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Hookshot, "Hookshot")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PowerCogs, "Power Cogs")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.RocketFlare, "Rocket Flare"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.CrystalMaiden, "Crystal Maiden"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Jungler, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ArcaneAura, "Arcane Aura")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CrystalNova, "Crystal Nova")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FreezingField, "Freezing Field")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Frostbite, "Frostbite"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.DarkSeer, "Dark Seer"), 
                AttackType.Melee, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Jungler },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IonShell, "Ion Shell")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Surge, "Surge")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Vacuum, "Vacuum")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WallReplica, "Wall of Replica"))
                })
            }));

            // TODO: добавить способности
            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.DarkWillow, "Dark Willow"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IonShell, "Ion Shell")),
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Surge, "Surge")),
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Vacuum, "Vacuum")),
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WallReplica, "Wall of Replica"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Dazzle, "Dazzle"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PoisonTouch, "Poison Touch")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShadowWave, "Shadow Wave")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShallowGrave, "Shallow Grave")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Weave, "Weave"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.DeathProphet, "Death Prophet"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CryptSwarm, "Crypt Swarm")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Exorcism, "Exorcism")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Silence, "Silence")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SpiritSiphon, "Spirit Siphon"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Disruptor, "Disruptor"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Glimpse, "Glimpse")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.KineticField, "Kinetic Field")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StaticStorm, "Static Storm")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ThunderStrike, "Thunder Strike"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Doom, "Doom"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Devour, "Devour")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Doom, "Doom")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.InfernalBlade, "Infernal Blade")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ScorchedEarth, "Scorched Earth"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.DragonKnight, "Dragon Knight"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BreatheFire, "Breathe Fire")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DragonBlood, "Dragon Blood")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DragonTail, "Dragon Tail")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ElderDragonForm, "Elder Dragon Form"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.DrowRanger, "Drow Ranger"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FrostArrows, "Frost Arrows")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Gust, "Gust")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Marksmanship, "Marksmanship")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PrecisionAura, "Precision Aura"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.EarthSpirit, "Earth Spirit"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BoulderSmash, "Boulder Smash")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EnchantRemnant, "Enchant Remnant")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GeomagneticGrip, "Geomagnetic Grip")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Magnetize, "Magnetize")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.RollingBoulder, "Rolling Boulder")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StoneRemnant, "Stone Remnant"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Earthshaker, "Earthshaker"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Aftershock, "Aftershock")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EchoSlam, "Echo Slam")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EnchantTotem, "Enchant Totem")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Fissure, "Fissure"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ElderTitan, "Elder Titan"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AstralSpirit, "Astral Spirit")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EarthSplitter, "Earth Splitter")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EchoStomp, "Echo Stomp")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.NaturalOrder, "Natural Order")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ReturnAstralSpirit, "Return Astral Spirit"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.EmberSpirit, "Ember Spirit"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ActivateFireRemnant, "Activate Fire Remnant")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FireRemnant, "Fire Remnant")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FlameGuard, "Flame Guard")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SearingChains, "Searing Chains")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SleightFist, "Sleight of Fist"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Enchantress, "Enchantress"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Jungler, HeroRole.Pusher, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Enchant, "Enchant")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Impetus, "Impetus")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.NatureAttendants, "Nature's Attendants")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Untouchable, "Untouchable"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Enigma, "Enigma"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Jungler, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BlackHole, "Black Hole")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DemonicConversion, "Demonic Conversion")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Malefice, "Malefice")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MidnightPulse, "Midnight Pulse"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.FacelessVoid, "Faceless Void"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Chronosphere, "Chronosphere")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TimeDilation, "Time Dilation")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TimeLock, "Time Lock")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TimeWalk, "Time Walk"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Gyrocopter, "Gyrocopter"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CallDown, "Call Down")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FlakCannon, "Flak Cannon")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.HomingMissile, "Homing Missile")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.RocketBarrage, "Rocket Barrage"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Huskar, "Huskar"), 
                AttackType.Ranged, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Initiator },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BerserkerBlood, "Berserker's Blood")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BurningSpear, "Burning Spear")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.InnerVitality, "Inner Vitality")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LifeBreak, "Life Break"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Invoker, "Invoker"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Alacrity, "Alacrity")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ChaosMeteor, "Chaos Meteor")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ColdSnap, "Cold Snap")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DeafeningBlast, "Deafening Blast")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EMP, "EMP")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Exort, "Exort")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ForgeSpirit, "Forge Spirit")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GhostWalk, "Ghost Walk")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IceWall, "Ice Wall")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Invoke, "Invoke")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.InvokerAttributeBonus, "invoker_attribute_bonus")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Quas, "Quas")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SunStrike, "Sun Strike")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Tornado, "Tornado")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Wex, "Wex"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Io, "Io"), 
                AttackType.Ranged, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Escape, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BreakTether, "Break Tether")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Overcharge, "Overcharge")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Relocate, "Relocate")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Spirits, "Spirits")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SpiritsIn, "Spirits In")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SpiritsOut, "Spirits Out")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Tether, "Tether"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Jakiro, "Jakiro"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DualBreath, "Dual Breath")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IcePath, "Ice Path")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LiquidFire, "Liquid Fire")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Macropyre, "Macropyre"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Juggernaut, "Juggernaut"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BladeDance, "Blade Dance")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BladeFury, "Blade Fury")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.HealingWard, "Healing Ward")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Omnislash, "Omnislash"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.KeeperOfTheLight, "Keeper of the Light"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Jungler, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BlindingLight, "Blinding Light")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ChakraMagic, "Chakra Magic")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Illuminate, "Illuminate")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IlluminateForm, "Illuminate")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ManaLeak, "Mana Leak")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Recall, "Recall")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ReleaseIlluminate, "Release Illuminate")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ReleaseIlluminateForm, "Release Illuminate")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SpiritForm, "Spirit Form"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Kunkka, "Kunkka"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Ghostship, "Ghostship")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ReturnXMarksSpot, "Return")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Tidebringer, "Tidebringer")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Torrent, "Torrent")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.XMarksSpot, "X Marks the Spot"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.LegionCommander, "Legion Commander"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Duel, "Duel")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MomentCourage, "Moment of Courage")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.OverwhelmingOdds, "Overwhelming Odds")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PressTheAttack, "Press The Attack"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Leshrac, "Leshrac"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DiabolicEdict, "Diabolic Edict")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LightningStorm, "Lightning Storm")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PulseNova, "Pulse Nova")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SplitEarth, "Split Earth"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Lich, "Lich"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ChainFrost, "Chain Frost")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FrostBlast, "Frost Blast")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IceArmor, "Ice Armor")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Sacrifice, "Sacrifice"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Lifestealer, "Lifestealer"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Jungler },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Assimilate, "Assimilate")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Consume, "Consume")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Control, "Control")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Eject, "Eject")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Feast, "Feast")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Infest, "Infest")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.OpenWounds, "Open Wounds")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Rage, "Rage"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Lina, "Lina"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DragonSlave, "Dragon Slave")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FierySoul, "Fiery Soul")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LagunaBlade, "Laguna Blade")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LightStrikeArray, "Light Strike Array"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Lion, "Lion"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EarthSpike, "Earth Spike")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FingerDeath, "Finger of Death")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.HexLion, "Hex")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ManaDrain, "Mana Drain"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.LoneDruid, "Lone Druid"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Jungler, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BattleCry, "Battle Cry")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DruidForm, "Druid Form")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Rabid, "Rabid")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SavageRoar, "Savage Roar")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SummonSpiritBear, "Summon Spirit Bear")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TrueForm, "True Form"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Luna, "Luna"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Eclipse, "Eclipse")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LucentBeam, "Lucent Beam")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LunarBlessing, "Lunar Blessing")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MoonGlaive, "Moon Glaive"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Lycan, "Lycan"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Escape, HeroRole.Jungler, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FeralImpulse, "Feral Impulse")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Howl, "Howl")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Shapeshift, "Shapeshift")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SummonWolves, "Summon Wolves"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Magnus, "Magnus"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Empower, "Empower")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ReversePolarity, "Reverse Polarity")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Shockwave, "Shockwave")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Skewer, "Skewer"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Medusa, "Medusa"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ManaShield, "Mana Shield")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MysticSnake, "Mystic Snake")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SplitShot, "Split Shot")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StoneGaze, "Stone Gaze"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Meepo, "Meepo"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DividedWeStand, "Divided We Stand")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Earthbind, "Earthbind")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Geostrike, "Geostrike")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Poof, "Poof"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Mirana, "Mirana"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Leap, "Leap")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MoonlightShadow, "Moonlight Shadow")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SacredArrow, "Sacred Arrow")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Starstorm, "Starstorm"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Morphling, "Morphling"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AdaptiveStrike, "Adaptive Strike")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Hybrid, "Hybrid")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MorphAgilityGain, "Morph (Agility Gain)")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MorphStrengthGain, "Morph (Strength Gain)")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MorphReplicate, "Morph Replicate")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Replicate, "Replicate")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Waveform, "Waveform"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.NagaSiren, "Naga Siren"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Pusher, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Ensnare, "Ensnare")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MirrorImage, "Mirror Image")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.RipTide, "Rip Tide")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SongSiren, "Song of the Siren")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SongSirenEnd, "Song of the Siren End"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.NatureProphet, "Nature's Prophet"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Jungler, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.NatureCall, "Nature's Call")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Sprout, "Sprout")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Teleportation, "Teleportation")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WrathNature, "Wrath of Nature"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Necrophos, "Necrophos"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DeathPulse, "Death Pulse")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.HeartstopperAura, "Heartstopper Aura")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ReaperScythe, "Reaper's Scythe")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Sadist, "Sadist"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.NightStalker, "Night Stalker"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CripplingFear, "Crippling Fear")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Darkness, "Darkness")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.HunterinNight, "Hunter in the Night")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Void, "Void"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.NyxAssassin, "Nyx Assassin"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Burrow, "Burrow")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Impale, "Impale")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ManaBurn, "Mana Burn")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SpikedCarapace, "Spiked Carapace")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Unburrow, "Unburrow")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Vendetta, "Vendetta"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.OgreMagi, "Ogre Magi"), 
                AttackType.Melee, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Bloodlust, "Bloodlust")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Fireblast, "Fireblast")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Ignite, "Ignite")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Multicast, "Multicast")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.UnrefinedFireblast, "Unrefined Fireblast"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Omniknight, "Omniknight"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Durable, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DegenAura, "Degen Aura")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GuardianAngel, "Guardian Angel")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Purification, "Purification")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Repel, "Repel"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Oracle, "Oracle"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FalsePromise, "False Promise")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FateEdict, "Fate's Edict")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FortuneEnd, "Fortune's End")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PurifyingFlames, "Purifying Flames"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.OutworldDevourer, "Outworld Devourer"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ArcaneOrb, "Arcane Orb")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AstralImprisonment, "Astral Imprisonment")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EssenceAura, "Essence Aura")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SanityEclipse, "Sanity's Eclipse"))
                })
            }));


            // TODO: добавить способности герою
            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Pangolier, "Pangolier"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ArcaneOrb, "Arcane Orb")),
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AstralImprisonment, "Astral Imprisonment")),
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EssenceAura, "Essence Aura")),
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SanityEclipse, "Sanity's Eclipse"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.PhantomAssassin, "Phantom Assassin"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Blur, "Blur")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CoupdeGrace, "Coup de Grace")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PhantomStrike, "Phantom Strike")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StiflingDagger, "Stifling Dagger"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.PhantomLancer, "Phantom Lancer"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Doppelganger, "Doppelganger")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Juxtapose, "Juxtapose")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PhantomRush, "Phantom Rush")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SpiritLance, "Spirit Lance"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Phoenix, "Phoenix"), 
                AttackType.Ranged, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FireSpirits, "Fire Spirits")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IcarusDive, "Icarus Dive")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LaunchFireSpirit, "Launch Fire Spirit")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StopIcarusDive, "Stop Icarus Dive")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StopSunRay, "Stop Sun Ray")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SunRay, "Sun Ray")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Supernova, "Supernova")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ToggleMovement, "Toggle Movement"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Puck, "Puck"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DreamCoil, "Dream Coil")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EtherealJaunt, "Ethereal Jaunt")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IllusoryOrb, "Illusory Orb")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PhaseShift, "Phase Shift")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WaningRift, "Waning Rift"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Pudge, "Pudge"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Dismember, "Dismember")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FleshHeap, "Flesh Heap")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MeatHook, "Meat Hook")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Rot, "Rot"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Pugna, "Pugna"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Decrepify, "Decrepify")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LifeDrain, "Life Drain")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.NetherBlast, "Nether Blast")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.NetherWard, "Nether Ward"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.QueenOfPain, "Queen of Pain"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BlinkQueenPain, "Blink")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ScreamOfPain, "Scream Of Pain")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShadowStrike, "Shadow Strike")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SonicWave, "Sonic Wave"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Razor, "Razor"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EyeStorm, "Eye of the Storm")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PlasmaField, "Plasma Field")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StaticLink, "Static Link")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.UnstableCurrent, "Unstable Current"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Riki, "Riki"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BlinkStrike, "Blink Strike")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CloakandDagger, "Cloak and Dagger")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SmokeScreen, "Smoke Screen")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TricksTrade, "Tricks of the Trade"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Rubick, "Rubick"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FadeBolt, "Fade Bolt")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.NullField, "Null Field")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SpellSteal, "Spell Steal")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Telekinesis, "Telekinesis")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TelekinesisLand, "Telekinesis Land"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.SandKing, "Sand King"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Jungler, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Burrowstrike, "Burrowstrike")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CausticFinale, "Caustic Finale")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Epicenter, "Epicenter")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SandStorm, "Sand Storm"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ShadowDemon, "Shadow Demon"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DemonicPurge, "Demonic Purge")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Disruption, "Disruption")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShadowPoison, "Shadow Poison")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShadowPoisonRelease, "Shadow Poison Release")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SoulCatcher, "Soul Catcher"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ShadowFiend, "Shadow Fiend"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Necromastery, "Necromastery")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PresenceDarkLord, "Presence of the Dark Lord")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.RequiemSouls, "Requiem of Souls")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShadowrazeQ, "Shadowraze")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShadowrazeW, "Shadowraze")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShadowrazeE, "Shadowraze"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.ShadowShaman, "Shadow Shaman"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EtherShock, "Ether Shock")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.HexRasta, "Hex")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MassSerpentWard, "Mass Serpent Ward")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Shackles, "Shackles"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Silencer, "Silencer"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ArcaneCurse, "Arcane Curse")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GlaivesWisdom, "Glaives of Wisdom")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GlobalSilence, "Global Silence")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LastWord, "Last Word"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.SkywrathMage, "Skywrath Mage"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AncientSeal, "Ancient Seal")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ArcaneBolt, "Arcane Bolt")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ConcussiveShot, "Concussive Shot")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MysticFlare, "Mystic Flare"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Slardar, "Slardar"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AmplifyDamage, "Amplify Damage")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Bash, "Bash")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SlithereenCrush, "Slithereen Crush")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Sprint, "Sprint"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Slark, "Slark"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DarkPact, "Dark Pact")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EssenceShift, "Essence Shift")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Pounce, "Pounce")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShadowDance, "Shadow Dance"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Sniper, "Sniper"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Assassinate, "Assassinate")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Headshot, "Headshot")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Shrapnel, "Shrapnel")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TakeAim, "Take Aim"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Spectre, "Spectre"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Durable, HeroRole.Escape },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Desolate, "Desolate")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Dispersion, "Dispersion")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Haunt, "Haunt")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Reality, "Reality")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SpectralDagger, "Spectral Dagger"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.SpiritBreaker, "Spirit Breaker"),
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ChargeDarkness, "Charge of Darkness")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EmpoweringHaste, "Empowering Haste")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GreaterBash, "Greater Bash")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.NetherStrike, "Nether Strike"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.StormSpirit, "Storm Spirit"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BallLightning, "Ball Lightning")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ElectricVortex, "Electric Vortex")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Overload, "Overload")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StaticRemnant, "Static Remnant"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Sven, "Sven"), 
                AttackType.Melee, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GodStrength, "God's Strength")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GreatCleave, "Great Cleave")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StormHammer, "Storm Hammer")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Warcry, "Warcry"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Techies, "Techies"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FocusedDetonate, "Focused Detonate")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LandMines, "Land Mines")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MinefieldSign, "Minefield Sign")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.RemoteMines, "Remote Mines")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StasisTrap, "Stasis Trap")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SuicideSquadAttack, "Suicide Squad, Attack!"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.TemplarAssassin, "Templar Assassin"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Meld, "Meld")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PsiBlades, "Psi Blades")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PsionicTrap, "Psionic Trap")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Refraction, "Refraction")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Trap, "Trap"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Terrorblade, "Terrorblade"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ConjureImage, "Conjure Image")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Metamorphosis, "Metamorphosis")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Reflection, "Reflection")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Sunder, "Sunder"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Tidehunter, "Tidehunter"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AnchorSmash, "Anchor Smash")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Gush, "Gush")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.KrakenShell, "Kraken Shell")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Ravage, "Ravage"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Timbersaw, "Timbersaw"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Durable, HeroRole.Escape, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ChakramBlue, "Chakram")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ChakramRed, "Chakram")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ReactiveArmor, "Reactive Armor")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ReturnChakramBlue, "Return Chakram")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ReturnChakramRed, "Return Chakram")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TimberChain, "Timber Chain")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WhirlingDeath, "Whirling Death"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Tinker, "Tinker"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.HeatSeekingMissile, "Heat-Seeking Missile")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Laser, "Laser")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MarchMachines, "March of the Machines")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Rearm, "Rearm"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Tiny, "Tiny"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Avalanche, "Avalanche")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CraggyExterior, "Craggy Exterior")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Grow, "Grow")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Toss, "Toss"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.TreantProtector, "Treant Protector"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Initiator, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.EyesInTheForest, "Eyes In The Forest")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LeechSeed, "Leech Seed")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LivingArmor, "Living Armor")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.NatureGuise, "Nature's Guise")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Overgrowth, "Overgrowth"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.TrollWarlord, "Troll Warlord"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Pusher },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BattleTrance, "Battle Trance")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.BerserkerRage, "Berserker's Rage")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Fervor, "Fervor")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WhirlingAxesMelee, "Whirling Axes (Melee)")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WhirlingAxesRanged, "Whirling Axes (Ranged)"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Tusk, "Tusk"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FrozenSigil, "Frozen Sigil")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.IceShards, "Ice Shards")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LaunchSnowball, "Launch Snowball")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Snowball, "Snowball")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WalrusKick, "Walrus Kick")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WalrusPUNCH, "Walrus PUNCH!"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Undying, "Undying"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Decay, "Decay")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FleshGolem, "Flesh Golem")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SoulRip, "Soul Rip")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Tombstone, "Tombstone"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Ursa, "Ursa"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Jungler },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Earthshock, "Earthshock")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Enrage, "Enrage")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FurySwipes, "Fury Swipes")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Overpower, "Overpower"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.VengefulSpirit, "Vengeful Spirit"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MagicMissile, "Magic Missile")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.NetherSwap, "Nether Swap")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.VengeanceAura, "Vengeance Aura")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WaveTerror, "Wave of Terror"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Venomancer, "Venomancer"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Initiator, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PlagueWard, "Plague Ward")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PoisonNova, "Poison Nova")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PoisonSting, "Poison Sting")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.VenomousGale, "Venomous Gale"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Viper, "Viper"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.CorrosiveSkin, "Corrosive Skin")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Nethertoxin, "Nethertoxin")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PoisonAttack, "Poison Attack")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ViperStrike, "Viper Strike"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Visage, "Visage"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Nuker, HeroRole.Pusher, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GraveChill, "Grave Chill")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GravekeeperCloak, "Gravekeeper's Cloak")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SoulAssumption, "Soul Assumption")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SummonFamiliars, "Summon Familiars"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Warlock, "Warlock"), 
                AttackType.Ranged, 
                HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Durable, HeroRole.Initiator, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ChaoticOffering, "Chaotic Offering")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FatalBonds, "Fatal Bonds")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ShadowWord, "Shadow Word")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Upheaval, "Upheaval"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Weaver, "Weaver"), 
                AttackType.Ranged, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Escape },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.GeminateAttack, "Geminate Attack")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Shukuchi, "Shukuchi")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TheSwarm, "The Swarm")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.TimeLapse, "Time Lapse"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Windranger, "Windranger"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.FocusFire, "Focus Fire")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Powershot, "Powershot")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Shackleshot, "Shackleshot")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Windrun, "Windrun"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.WinterWyvern, "Winter Wyvern"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ArcticBurn, "Arctic Burn")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ColdEmbrace, "Cold Embrace")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.SplinterBlast, "Splinter Blast")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WinterCurse, "Winter's Curse"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.WitchDoctor, "Witch Doctor"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DeathWard, "Death Ward")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Maledict, "Maledict")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ParalyzingCask, "Paralyzing Cask")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.VoodooRestoration, "Voodoo Restoration"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.WraithKing, "Wraith King"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Durable, HeroRole.Initiator, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.MortalStrike, "Mortal Strike")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Reincarnation, "Reincarnation")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.VampiricAura, "Vampiric Aura")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.WraithfireBlast, "Wraithfire Blast"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Zeus, "Zeus"), 
                AttackType.Ranged, HeroCharacteristic.Intelligence,
                new List<HeroRole> { HeroRole.Nuker },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ArcLightning, "Arc Lightning")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.LightningBolt, "Lightning Bolt")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.StaticField, "Static Field")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.ThundergodWrath, "Thundergod's Wrath"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.Underlord, "Underlord"), 
                AttackType.Melee, HeroCharacteristic.Strength,
                new List<HeroRole> { HeroRole.Disabler, HeroRole.Durable, HeroRole.Escape, HeroRole.Nuker, HeroRole.Support },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Firestorm, "Firestorm")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PitMalice, "Pit of Malice")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AtrophyAura, "Atrophy Aura")),
                    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DarkRift, "Dark Rift"))
                })
            }));

            Items.Add(DotaHero.Factory.CreateElement(new List<object>()
            {
                new DotaName<Hero>(Hero.MonkeyKing, "Monkey King"), 
                AttackType.Melee, HeroCharacteristic.Agility,
                new List<HeroRole> { HeroRole.Carry, HeroRole.Disabler, HeroRole.Escape, HeroRole.Initiator },
                new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>
                {
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.Firestorm, "Firestorm")),
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.PitMalice, "Pit of Malice")),
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.AtrophyAura, "Atrophy Aura")),
                    //DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.DarkRift, "Dark Rift"))
                })
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
