using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker.Collections
{
    public class DotaHeroAbilityCollection : ReadOnlyCollection<DotaHeroAbility>
    {
        #region Constructors

        private DotaHeroAbilityCollection()
            : base(new List<DotaHeroAbility>())
        {
            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.AcidSpray, "Acid Spray")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ActivateFireRemnant, "Activate Fire Remnant")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.AdaptiveStrike, "Adaptive Strike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Aftershock, "Aftershock")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Alacrity, "Alacrity")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.AmplifyDamage, "Amplify Damage")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.AnchorSmash, "Anchor Smash")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.AncientSeal, "Ancient Seal")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.AphoticShield, "Aphotic Shield")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ArcLightning, "Arc Lightning")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ArcaneAura, "Arcane Aura")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ArcaneBolt, "Arcane Bolt")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ArcaneCurse, "Arcane Curse")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ArcaneOrb, "Arcane Orb")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ArcticBurn, "Arctic Burn")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Assassinate, "Assassinate")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Assimilate, "Assimilate")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.AstralImprisonment, "Astral Imprisonment")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.AstralSpirit, "Astral Spirit")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Avalanche, "Avalanche")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BallLightning, "Ball Lightning")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Bash, "Bash")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BatteryAssault, "Battery Assault")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BattleCry, "Battle Cry")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BattleHunger, "Battle Hunger")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BattleTrance, "Battle Trance")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BerserkerBlood, "Berserker's Blood")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BerserkerCall, "Berserker's Call")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BerserkerRage, "Berserker's Rage")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BlackHole, "Black Hole")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BladeDance, "Blade Dance")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BladeFury, "Blade Fury")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BlindingLight, "Blinding Light")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BlinkAntiMage, "Blink")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BlinkQueenPain, "Blink")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BlinkStrike, "Blink Strike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BloodRite, "Blood Rite")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Bloodlust, "Bloodlust")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Bloodrage, "Bloodrage")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Blur, "Blur")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BorrowedTime, "Borrowed Time")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BoulderSmash, "Boulder Smash")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BrainSap, "Brain Sap")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BreakTether, "Break Tether")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BreatheFire, "Breathe Fire")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Bristleback, "Bristleback")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.BurningSpear, "Burning Spear")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Burrow, "Burrow")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Burrowstrike, "Burrowstrike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CallDown, "Call Down")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CallWildBoar, "Call of the Wild: Boar")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CallWildHawk, "Call of the Wild: Hawk")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CausticFinale, "Caustic Finale")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ChainFrost, "Chain Frost")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ChakraMagic, "Chakra Magic")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ChakramBlue, "Chakram")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ChakramRed, "Chakram")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ChaosBolt, "Chaos Bolt")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ChaosMeteor, "Chaos Meteor")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ChaosStrike, "Chaos Strike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ChaoticOffering, "Chaotic Offering")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ChargeDarkness, "Charge of Darkness")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ChemicalRage, "Chemical Rage")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ChillingTouch, "Chilling Touch")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Chronosphere, "Chronosphere")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CloakandDagger, "Cloak and Dagger")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ColdEmbrace, "Cold Embrace")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ColdFeet, "Cold Feet")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ColdSnap, "Cold Snap")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ConcussiveShot, "Concussive Shot")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ConjureImage, "Conjure Image")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Consume, "Consume")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Control, "Control")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CorrosiveSkin, "Corrosive Skin")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CounterHelix, "Counter Helix")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CoupdeGrace, "Coup de Grace")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CraggyExterior, "Craggy Exterior")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CripplingFear, "Crippling Fear")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CryptSwarm, "Crypt Swarm")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CrystalNova, "Crystal Nova")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CullingBlade, "Culling Blade")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.CurseAvernus, "Curse of Avernus")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DarkPact, "Dark Pact")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Darkness, "Darkness")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DeafeningBlast, "Deafening Blast")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DeathPact, "Death Pact")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DeathPulse, "Death Pulse")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DeathWard, "Death Ward")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Decay, "Decay")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Decrepify, "Decrepify")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DegenAura, "Degen Aura")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DemonicConversion, "Demonic Conversion")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DemonicPurge, "Demonic Purge")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Desolate, "Desolate")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Devour, "Devour")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DiabolicEdict, "Diabolic Edict")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Dismember, "Dismember")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Dispersion, "Dispersion")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Disruption, "Disruption")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DividedWeStand, "Divided We Stand")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Doom, "Doom")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Doppelganger, "Doppelganger")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DoubleEdge, "Double Edge")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DragonBlood, "Dragon Blood")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DragonSlave, "Dragon Slave")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DragonTail, "Dragon Tail")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DreamCoil, "Dream Coil")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DruidForm, "Druid Form")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DrunkenBrawler, "Drunken Brawler")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DrunkenHaze, "Drunken Haze")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.DualBreath, "Dual Breath")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Duel, "Duel")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EarthSpike, "Earth Spike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EarthSplitter, "Earth Splitter")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Earthbind, "Earthbind")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Earthshock, "Earthshock")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EchoSlam, "Echo Slam")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EchoStomp, "Echo Stomp")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Eclipse, "Eclipse")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Eject, "Eject")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ElderDragonForm, "Elder Dragon Form")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ElectricVortex, "Electric Vortex")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EMP, "EMP")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Empower, "Empower")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EmpoweringHaste, "Empowering Haste")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Enchant, "Enchant")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EnchantRemnant, "Enchant Remnant")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EnchantTotem, "Enchant Totem")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Enfeeble, "Enfeeble")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Enrage, "Enrage")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Ensnare, "Ensnare")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Epicenter, "Epicenter")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EssenceAura, "Essence Aura")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EssenceShift, "Essence Shift")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EtherShock, "Ether Shock")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EtherealJaunt, "Ethereal Jaunt")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Exorcism, "Exorcism")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Exort, "Exort")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EyeStorm, "Eye of the Storm")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.EyesInTheForest, "Eyes In The Forest")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FadeBolt, "Fade Bolt")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FalsePromise, "False Promise")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FatalBonds, "Fatal Bonds")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FateEdict, "Fate's Edict")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Feast, "Feast")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FeralImpulse, "Feral Impulse")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Fervor, "Fervor")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FiendGrip, "Fiend's Grip")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FierySoul, "Fiery Soul")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FingerDeath, "Finger of Death")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FireRemnant, "Fire Remnant")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FireSpirits, "Fire Spirits")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Fireblast, "Fireblast")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Firefly, "Firefly")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Fissure, "Fissure")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FlakCannon, "Flak Cannon")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FlameGuard, "Flame Guard")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Flamebreak, "Flamebreak")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FlamingLasso, "Flaming Lasso")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FleshGolem, "Flesh Golem")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FleshHeap, "Flesh Heap")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Flux, "Flux")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FocusFire, "Focus Fire")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FocusedDetonate, "Focused Detonate")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ForgeSpirit, "Forge Spirit")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FortuneEnd, "Fortune's End")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FreezingField, "Freezing Field")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FrostArrows, "Frost Arrows")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FrostBlast, "Frost Blast")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Frostbite, "Frostbite")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FrozenSigil, "Frozen Sigil")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.FurySwipes, "Fury Swipes")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GeminateAttack, "Geminate Attack")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GeomagneticGrip, "Geomagnetic Grip")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Geostrike, "Geostrike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GhostWalk, "Ghost Walk")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Ghostship, "Ghostship")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GlaivesWisdom, "Glaives of Wisdom")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Glimpse, "Glimpse")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GlobalSilence, "Global Silence")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GodStrength, "God's Strength")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GraveChill, "Grave Chill")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GravekeeperCloak, "Gravekeeper's Cloak")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GreatCleave, "Great Cleave")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GreaterBash, "Greater Bash")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GreevilGreed, "Greevil's Greed")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Grow, "Grow")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.GuardianAngel, "Guardian Angel")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Gush, "Gush")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Gust, "Gust")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.HandGod, "Hand of God")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Haunt, "Haunt")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Headshot, "Headshot")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.HealingWard, "Healing Ward")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.HeartstopperAura, "Heartstopper Aura")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.HeatSeekingMissile, "Heat-Seeking Missile")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.HexLion, "Hex")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.HexRasta, "Hex")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.HolyPersuasion, "Holy Persuasion")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.HomingMissile, "Homing Missile")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.HoofStomp, "Hoof Stomp")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Hookshot, "Hookshot")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Howl, "Howl")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.HunterinNight, "Hunter in the Night")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Hybrid, "Hybrid")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.IcarusDive, "Icarus Dive")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.IceArmor, "Ice Armor")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.IceBlast, "Ice Blast")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.IcePath, "Ice Path")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.IceShards, "Ice Shards")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.IceVortex, "Ice Vortex")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.IceWall, "Ice Wall")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Ignite, "Ignite")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Illuminate, "Illuminate")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Illuminate, "Illuminate")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.IllusoryOrb, "Illusory Orb")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Impale, "Impale")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Impetus, "Impetus")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.IncapacitatingBite, "Incapacitating Bite")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.InfernalBlade, "Infernal Blade")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Infest, "Infest")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.InnerBeast, "Inner Beast")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.InnerVitality, "Inner Vitality")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.InsatiableHunger, "Insatiable Hunger")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Invoke, "Invoke")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.InvokerAttributeBonus, "invoker_attribute_bonus")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.IonShell, "Ion Shell")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Jinada, "Jinada")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Juxtapose, "Juxtapose")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.KineticField, "Kinetic Field")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.KrakenShell, "Kraken Shell")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LagunaBlade, "Laguna Blade")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LandMines, "Land Mines")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Laser, "Laser")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LastWord, "Last Word")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LaunchFireSpirit, "Launch Fire Spirit")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LaunchSnowball, "Launch Snowball")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Leap, "Leap")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LeechSeed, "Leech Seed")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LifeBreak, "Life Break")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LifeDrain, "Life Drain")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LightStrikeArray, "Light Strike Array")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LightningBolt, "Lightning Bolt")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LightningStorm, "Lightning Storm")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LiquidFire, "Liquid Fire")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LivingArmor, "Living Armor")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LucentBeam, "Lucent Beam")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.LunarBlessing, "Lunar Blessing")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Macropyre, "Macropyre")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MagicMissile, "Magic Missile")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MagneticField, "Magnetic Field")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Magnetize, "Magnetize")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Maledict, "Maledict")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Malefice, "Malefice")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ManaBreak, "Mana Break")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ManaBurn, "Mana Burn")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ManaDrain, "Mana Drain")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ManaLeak, "Mana Leak")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ManaShield, "Mana Shield")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ManaVoid, "Mana Void")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MarchMachines, "March of the Machines")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Marksmanship, "Marksmanship")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MassSerpentWard, "Mass Serpent Ward")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MeatHook, "Meat Hook")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Meld, "Meld")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Metamorphosis, "Metamorphosis")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MidnightPulse, "Midnight Pulse")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MinefieldSign, "Minefield Sign")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MirrorImage, "Mirror Image")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MistCoil, "Mist Coil")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MomentCourage, "Moment of Courage")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MoonGlaive, "Moon Glaive")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MoonlightShadow, "Moonlight Shadow")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MorphAgilityGain, "Morph (Agility Gain)")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MorphStrengthGain, "Morph (Strength Gain)")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MorphReplicate, "Morph Replicate")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MortalStrike, "Mortal Strike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Multicast, "Multicast")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MysticFlare, "Mystic Flare")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.MysticSnake, "Mystic Snake")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.NaturalOrder, "Natural Order")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.NatureAttendants, "Nature's Attendants")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.NatureCall, "Nature's Call")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.NatureGuise, "Nature's Guise")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Necromastery, "Necromastery")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.NetherBlast, "Nether Blast")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.NetherStrike, "Nether Strike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.NetherSwap, "Nether Swap")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.NetherWard, "Nether Ward")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Nethertoxin, "Nethertoxin")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Nightmare, "Nightmare")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.NightmareEnd, "Nightmare End")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.NullField, "Null Field")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Omnislash, "Omnislash")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.OpenWounds, "Open Wounds")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Overcharge, "Overcharge")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Overgrowth, "Overgrowth")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Overload, "Overload")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Overpower, "Overpower")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.OverwhelmingOdds, "Overwhelming Odds")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ParalyzingCask, "Paralyzing Cask")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Penitence, "Penitence")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Phantasm, "Phantasm")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PhantomRush, "Phantom Rush")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PhantomStrike, "Phantom Strike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PhaseShift, "Phase Shift")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PlagueWard, "Plague Ward")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PlasmaField, "Plasma Field")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PoisonAttack, "Poison Attack")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PoisonNova, "Poison Nova")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PoisonSting, "Poison Sting")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PoisonTouch, "Poison Touch")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Poof, "Poof")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Pounce, "Pounce")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PowerCogs, "Power Cogs")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Powershot, "Powershot")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PrecisionAura, "Precision Aura")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PresenceDarkLord, "Presence of the Dark Lord")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PressTheAttack, "Press The Attack")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PrimalRoar, "Primal Roar")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PrimalSplit, "Primal Split")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PsiBlades, "Psi Blades")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PsionicTrap, "Psionic Trap")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PulseNova, "Pulse Nova")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Purification, "Purification")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.PurifyingFlames, "Purifying Flames")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Quas, "Quas")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.QuillSpray, "Quill Spray")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Rabid, "Rabid")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Rage, "Rage")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Ravage, "Ravage")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ReactiveArmor, "Reactive Armor")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Reality, "Reality")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.RealityRift, "Reality Rift")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ReaperScythe, "Reaper's Scythe")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Rearm, "Rearm")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Recall, "Recall")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Reflection, "Reflection")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Refraction, "Refraction")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Reincarnation, "Reincarnation")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Release, "Release")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ReleaseIlluminate, "Release Illuminate")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ReleaseIlluminate, "Release Illuminate")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Relocate, "Relocate")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.RemoteMines, "Remote Mines")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Repel, "Repel")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Replicate, "Replicate")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.RequiemSouls, "Requiem of Souls")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Return, "Return")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Return, "Return")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ReturnAstralSpirit, "Return Astral Spirit")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ReturnChakramBlue, "Return Chakram")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ReturnChakramRed, "Return Chakram")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ReversePolarity, "Reverse Polarity")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.RipTide, "Rip Tide")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.RocketBarrage, "Rocket Barrage")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.RocketFlare, "Rocket Flare")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.RollingBoulder, "Rolling Boulder")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Rot, "Rot")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Rupture, "Rupture")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SacredArrow, "Sacred Arrow")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Sacrifice, "Sacrifice")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Sadist, "Sadist")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SandStorm, "Sand Storm")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SanityEclipse, "Sanity's Eclipse")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SavageRoar, "Savage Roar")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ScorchedEarth, "Scorched Earth")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ScreamOfPain, "Scream Of Pain")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SearingArrows, "Searing Arrows")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SearingChains, "Searing Chains")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Shackles, "Shackles")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Shackleshot, "Shackleshot")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShadowDance, "Shadow Dance")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShadowPoison, "Shadow Poison")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShadowPoisonRelease, "Shadow Poison Release")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShadowStrike, "Shadow Strike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShadowWalk, "Shadow Walk")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShadowWave, "Shadow Wave")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShadowWord, "Shadow Word")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShadowrazeQ, "Shadowraze")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShadowrazeW, "Shadowraze")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShadowrazeE, "Shadowraze")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShallowGrave, "Shallow Grave")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Shapeshift, "Shapeshift")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Shockwave, "Shockwave")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Shrapnel, "Shrapnel")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Shukuchi, "Shukuchi")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ShurikenToss, "Shuriken Toss")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Silence, "Silence")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SkeletonWalk, "Skeleton Walk")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Skewer, "Skewer")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SleightFist, "Sleight of Fist")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SlithereenCrush, "Slithereen Crush")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SmokeScreen, "Smoke Screen")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Snowball, "Snowball")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SongSiren, "Song of the Siren")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SongSirenEnd, "Song of the Siren End")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SonicWave, "Sonic Wave")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SoulAssumption, "Soul Assumption")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SoulCatcher, "Soul Catcher")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SoulRip, "Soul Rip")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SparkWraith, "Spark Wraith")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SpawnSpiderlings, "Spawn Spiderlings")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SpectralDagger, "Spectral Dagger")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SpellShield, "Spell Shield")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SpellSteal, "Spell Steal")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SpikedCarapace, "Spiked Carapace")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SpinWeb, "Spin Web")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SpiritForm, "Spirit Form")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SpiritLance, "Spirit Lance")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SpiritSiphon, "Spirit Siphon")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Spirits, "Spirits")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SpiritsIn, "Spirits In")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SpiritsOut, "Spirits Out")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SplinterBlast, "Splinter Blast")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SplitEarth, "Split Earth")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SplitShot, "Split Shot")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Sprint, "Sprint")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Sprout, "Sprout")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Stampede, "Stampede")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Starstorm, "Starstorm")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StasisTrap, "Stasis Trap")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StaticField, "Static Field")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StaticLink, "Static Link")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StaticRemnant, "Static Remnant")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StaticStorm, "Static Storm")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StickyNapalm, "Sticky Napalm")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StiflingDagger, "Stifling Dagger")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StoneGaze, "Stone Gaze")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StoneRemnant, "Stone Remnant")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StopIcarusDive, "Stop Icarus Dive")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StopSunRay, "Stop Sun Ray")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.StormHammer, "Storm Hammer")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Strafe, "Strafe")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SuicideSquadAttack, "Suicide Squad, Attack!")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SummonFamiliars, "Summon Familiars")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SummonSpiritBear, "Summon Spirit Bear")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SummonWolves, "Summon Wolves")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SunRay, "Sun Ray")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.SunStrike, "Sun Strike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Sunder, "Sunder")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Supernova, "Supernova")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Surge, "Surge")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TakeAim, "Take Aim")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Telekinesis, "Telekinesis")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TelekinesisLand, "Telekinesis Land")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Teleportation, "Teleportation")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TempestDouble, "Tempest Double")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TestFaithDamage, "Test of Faith")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TestFaithTeleport, "Test of Faith")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Tether, "Tether")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TheSwarm, "The Swarm")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Thirst, "Thirst")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ThunderClap, "Thunder Clap")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ThunderStrike, "Thunder Strike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ThundergodWrath, "Thundergod's Wrath")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Tidebringer, "Tidebringer")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TimberChain, "Timber Chain")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TimeDilation, "Time Dilation")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TimeLapse, "Time Lapse")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TimeLock, "Time Lock")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TimeWalk, "Time Walk")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ToggleMovement, "Toggle Movement")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Tombstone, "Tombstone")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Tornado, "Tornado")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Torrent, "Torrent")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Toss, "Toss")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Track, "Track")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Trap, "Trap")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TricksTrade, "Tricks of the Trade")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.TrueForm, "True Form")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Unburrow, "Unburrow")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.UnrefinedFireblast, "Unrefined Fireblast")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.UnstableConcoction, "Unstable Concoction")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.UnstableConcoctionThrow, "Unstable Concoction Throw")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.UnstableCurrent, "Unstable Current")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Untouchable, "Untouchable")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Upheaval, "Upheaval")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Vacuum, "Vacuum")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.VampiricAura, "Vampiric Aura")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Vendetta, "Vendetta")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.VengeanceAura, "Vengeance Aura")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.VenomousGale, "Venomous Gale")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ViperStrike, "Viper Strike")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.ViscousNasalGoo, "Viscous Nasal Goo")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Void, "Void")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.VoodooRestoration, "Voodoo Restoration")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WallReplica, "Wall of Replica")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WalrusKick, "Walrus Kick")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WalrusPUNCH, "Walrus PUNCH!")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WaningRift, "Waning Rift")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Warcry, "Warcry")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Warpath, "Warpath")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WaveTerror, "Wave of Terror")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Waveform, "Waveform")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Weave, "Weave")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Wex, "Wex")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WhirlingAxesMelee, "Whirling Axes (Melee)")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WhirlingAxesRanged, "Whirling Axes (Ranged)")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WhirlingDeath, "Whirling Death")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WildAxes, "Wild Axes")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.Windrun, "Windrun")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WinterCurse, "Winter's Curse")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WraithfireBlast, "Wraithfire Blast")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.WrathNature, "Wrath of Nature")
            }));

            Items.Add(DotaHeroAbility.Factory.CreateElement(new List<object>()
            {
                new DotaName<Ability>(Ability.XMarksSpot, "X Marks the Spot")
            }));
        }

        #endregion
    }
}
