using NUnit.Framework;
using FakeItEasy;
using SpaceXAPI.Core.Services;
using SpaceXAPI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceXAPI.Tests
{
    [TestFixture]
    public class LaunchpadServiceShould
    {
        private ILaunchPadService _service;
        private ISpaceXRepository fakeRepo;

        [OneTimeSetUp]
        public void Setup()
        {
            fakeRepo = A.Fake<ISpaceXRepository>();
            _service = new LaunchpadService(fakeRepo);
        }


        [Test]
        public async Task CallingGetAllLaunchpadsAsync_CallsRepoGetLaunchpadsAsync_ReturnsExpectedResults()
        {
            var returnData = new List<Models.Launchpad>() { new Models.Launchpad() { Id = "v_crt_123", Name = "Nashville Launch Center", Status = "Under Construction" } };
            A.CallTo(() => fakeRepo.GetLaunchpadsAsync()).Returns(returnData);
            var result = await _service.GetAllLaunchpadsAsync();

            A.CallTo(() => fakeRepo.GetLaunchpadsAsync()).MustHaveHappened();
            Assert.AreEqual(1, result.Count);
        }
    }
}
