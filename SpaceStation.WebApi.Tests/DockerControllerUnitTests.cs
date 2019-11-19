using System;
using System.Net;
using System.Threading.Tasks;
using AutoMoqCore;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpaceStation.Models;
using SpaceStation.Repository.Interfaces;
using SpaceStation.WebApi.Controllers;
using Xunit;

namespace SpaceStation.WebApi.Tests
{
    public class DockerControllerUnitTests
    {
        [Fact]
        public void CallingConstructor()
        {
            // Arrange 
            var automoq = new AutoMoqer();

            // Act
            Action action = () => { automoq.Create<DockerController>(); };

            // Assert
            action.Should().NotThrow<Exception>();

        }

        [Fact]
        public void OnDock_SuccessfullyDocked()
        {
            // Arrange 
            var automoq = new AutoMoqer();

            var dockerController = automoq.Create<DockerController>();

            var dockRepository = automoq.GetMock<IDockRepository>();
            dockRepository.Setup(x => x.Dock(It.IsAny<Shuttle>())).Returns(Task.FromResult(true));

            

            // Act
            var result = dockerController.Dock(new Models.Models.Shuttle()) as OkResult;

            // Assert
            result?.StatusCode.Should().Be((int) HttpStatusCode.OK);

        }
    }
}
