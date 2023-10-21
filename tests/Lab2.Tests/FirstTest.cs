using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FirstTest
{
    public static IEnumerable<object[]> TestParameters()
    {
        var database = new Repository();

        IComponent? cpu = database.FindComponent("Xeon X5690");
        IComponent? ddr = database.FindComponent();

        yield return new object[] { cpu }
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void TestRouteForSpaceships(ICpu cpu)
    {
        // Arrange
        IComputerBuilder computerBuilder = new ComputerBuilder().WithCpu(cpu);
        Computer computer = computerBuilder.Build();

        const AnalizatorStatus expectedOutput = AnalizatorStatus.Valid;

        // Act
        var result = new ComputerValidationAnalysis(computer);

        // Assert
        Assert.Equal(expectedOutput, result.Status);
    }
}