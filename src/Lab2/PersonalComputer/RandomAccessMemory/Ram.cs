namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class Ram : IRam
{
    public Ram(int numberOfRamPads, int memorySize, DdrVersion ddrVersion, int ddrFrequency, RamFormFactor formFactor, int powerConsumption)
    {
        NumberOfRamPads = numberOfRamPads;
        MemorySize = memorySize;
        DdrVersion = ddrVersion;
        DdrFrequency = ddrFrequency;
        FormFactor = formFactor;
        PowerConsumption = powerConsumption;
    }

    public string? Name { get; private set; }
    public int NumberOfRamPads { get; private set; }
    public int MemorySize { get; private set; }
    public DdrVersion DdrVersion { get; private set; }
    public int DdrFrequency { get; private set; }
    public RamFormFactor FormFactor { get; private set; }
    public int PowerConsumption { get; private set; }

    public Ram Clone()
    {
        return new Ram(
            NumberOfRamPads,
            MemorySize,
            DdrVersion,
            DdrFrequency,
            FormFactor,
            PowerConsumption);
    }

    public Ram SetRamName(string name)
    {
        Ram ramClone = Clone();

        ramClone.Name = name;

        return ramClone;
    }

    public Ram SetRamNumberOfRamPads(int numberOfRamPads)
    {
        Ram ramClone = Clone();

        ramClone.NumberOfRamPads = numberOfRamPads;

        return ramClone;
    }

    public Ram SetRamMemorySize(int memorySize)
    {
        Ram ramClone = Clone();

        ramClone.MemorySize = memorySize;

        return ramClone;
    }

    public Ram SetRamDdrVersion(DdrVersion ddrVersion)
    {
        Ram ramClone = Clone();

        ramClone.DdrVersion = ddrVersion;

        return ramClone;
    }

    public Ram SetRamDdrFrequency(int ddrFrequency)
    {
        Ram ramClone = Clone();

        ramClone.DdrFrequency = ddrFrequency;

        return ramClone;
    }

    public Ram SetRamDdrFrequency(RamFormFactor formFactor)
    {
        Ram ramClone = Clone();

        ramClone.FormFactor = formFactor;

        return ramClone;
    }

    public Ram SetRamPowerConsumption(int powerConsumption)
    {
        Ram ramClone = Clone();

        ramClone.PowerConsumption = powerConsumption;

        return ramClone;
    }
}