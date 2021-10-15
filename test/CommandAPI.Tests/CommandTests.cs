using System;
using Xunit;
using CommandAPI.Models;

namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;

        public CommandTests()
        {
            testCommand = new Command
            {
                HowTo = "Do somethig awesome",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };
        }

        public void Dispose()
        {
            testCommand = null;
        }

        [Fact]
        public void CanChangeHowTo()
        {
            // Arrange

            // Act
            testCommand.HowTo = "Execute Unit Tests";

            // Assert
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }

        [Fact]
        public void CanChangePlatformTo()
        {
            // Arrange

            //When
            testCommand.Platform = "This is nice test";

            //Then
            Assert.Equal("This is nice test", testCommand.Platform);
        }

        [Fact]
        public void CanChangeCommandLineTo()
        {
            // Arrange

            //When
            testCommand.CommandLine = "it will work";

            //Then
            Assert.Equal("it will work", testCommand.CommandLine);
        }


    }
}