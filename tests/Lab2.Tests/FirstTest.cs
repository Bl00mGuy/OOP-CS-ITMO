using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FirstTest
{
    public static IEnumerable<object[]> TestParameters()
    {
        var database = new Repository();

        ICpu cpu = database.FindComponent("Ryzen 5 3600");
        IRam 

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