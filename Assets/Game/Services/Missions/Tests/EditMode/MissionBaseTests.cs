using Game.Services.Missions.Scripts;
using Game.Services.Missions.Scripts.Base;
using Game.Services.Missions.Scripts.Config;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Game.Services.Missions.Tests.EditMode
{
    public class MissionBaseTests
    {
        [Test]
        public void Collect_WhenInProgress_DoesNotCollect()
        {
            var mission = new TestMission();
            LogAssert.Expect(LogType.Warning, "Tried to collect an uncompleted mission");

            mission.Collect();

            Assert.That(mission.State, Is.EqualTo(EMissionState.InProgress));
        }

        private class TestMission : MissionBase
        {
            public TestMission() : base(new MissionConfig())
            {
            }
        }
    }
}
