using System;
using Xunit;
using Moq;
using AutoMapper;
using CommandAPI.Data;
using CommandAPI.Contrllers;
using CommandAPI.Profiles;
using CommandAPI.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Dtos;
namespace CommandAPI.Tests
{
    public class CommandsControllerTests : IDisposable
    {
        Mock<ICommandAPIRepo> mockRepo;
        CommandsProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        public CommandsControllerTests()
        {
            mockRepo = new Mock<ICommandAPIRepo>();

            realProfile = new CommandsProfile();

            configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(realProfile));

            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo = null;
            realProfile = null;
            configuration = null;
            mapper = null;
        }

        [Fact]
        public void GetCommandItems_Returns200_OK_WhenDbIsEmpty()
        {
            //Arrange
            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(0));

            var realProfile = new CommandsProfile();

            var controller = new CommandsController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetAllCommands();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }


        private List<Command> GetCommands(int num)
        {
            var commands = new List<Command>();
            if (num > 0)
            {
                commands.Add(
                    new Command
                    {
                        Id = 0,
                        HowTo = "How to generate a migration",
                        CommandLine = "dotnet ef migrations add <Name of Migration>",
                        Platform = ".Net Core EF"
                    }
                );
            }

            return commands;
        }
    }
}