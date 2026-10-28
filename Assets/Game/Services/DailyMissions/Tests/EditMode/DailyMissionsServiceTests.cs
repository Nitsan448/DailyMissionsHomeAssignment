using System.Linq;
using Core.Tests.Utilities;
using Game.Services.DailyMissions.Scripts.Config;
using Game.Services.DailyMissions.Scripts.MissionImplementations;
using Game.Services.DailyMissions.Scripts.Service;
using Game.Services.Missions.Scripts;
using Game.Services.Missions.Scripts.Base;
using Game.Services.Missions.Scripts.Config;
using Game.Services.Missions.Scripts.Implementations;
using NUnit.Framework;
using UnityEngine;

namespace Game.Services.DailyMissions.Tests.EditMode
{
    public class DailyMissionsServiceTests
    {
        private DailyMissionsConfig _config;
        private DailyMissionsService _service;

        [SetUp]
        public void SetUp()
        {
            _config = ScriptableObject.CreateInstance<DailyMissionsConfig>();
            ReflectionUtilities.SetProperty(_config, nameof(DailyMissionsConfig.DailyMissionsCount), 2);
            ReflectionUtilities.SetProperty(_config, nameof(DailyMissionsConfig.AlwaysIncludedMissions), new[] { CreateMissionConfig(MissionType.DailyMissionsStreak) });
            ReflectionUtilities.SetProperty(_config, nameof(DailyMissionsConfig.Missions), new[]
            {
                CreateMissionConfig(MissionType.Manual),
                CreateMissionConfig(MissionType.Manual),
                CreateMissionConfig(MissionType.Manual),
            });

            var streakFactory = new StreakMissionFactory();
            _service = new DailyMissionsService(_config, new MissionsFactory(new IMissionFactory[] { new ManualMissionFactory(), streakFactory }));
            streakFactory.Service = _service;
            _service.Initialize();
        }

        [TearDown]
        public void TearDown()
        {
            _service.Dispose();
            Object.DestroyImmediate(_config);
        }

        [Test]
        public void Initialize_CreatesAlwaysIncludedPlusDailyCountMissions()
        {
            var missionConfigs = _service.Missions.Select(m => m.Config).ToList();

            Assert.That(missionConfigs, Has.Count.EqualTo(3));
            Assert.That(_config.AlwaysIncludedMissions, Is.SubsetOf(missionConfigs));
        }

        [Test]
        public void StreakMission_CompletesOnlyAfterAllOtherMissionsAreCollected()
        {
            var streakMission = _service.Missions.OfType<DailyMissionsStreakMission>().Single();
            var manualMissions = _service.Missions.OfType<ManualMission>().ToList();

            manualMissions[0].Complete();
            manualMissions[0].Collect();
            manualMissions[1].Complete();
            Assert.That(streakMission.State, Is.EqualTo(EMissionState.InProgress));

            manualMissions[1].Collect();
            Assert.That(streakMission.State, Is.EqualTo(EMissionState.Completed));
        }

        private static MissionConfig CreateMissionConfig(MissionType type)
        {
            var config = new MissionConfig();
            ReflectionUtilities.SetProperty(config, nameof(MissionConfig.Type), type);
            return config;
        }

        // Mirrors DailyMissionsStreakMissionFactory, which resolves the service lazily to break the service <-> factory cycle.
        private class StreakMissionFactory : IMissionFactory
        {
            public MissionType Type => MissionType.DailyMissionsStreak;
            public IDailyMissionsService Service { get; set; }

            public MissionBase Create(MissionConfig config)
            {
                return new DailyMissionsStreakMission(config, Service);
            }
        }
    }
}
