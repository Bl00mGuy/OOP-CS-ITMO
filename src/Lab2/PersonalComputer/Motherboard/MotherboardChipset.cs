using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

public class MotherboardChipset : IChipset
{
    public MotherboardChipset(IList<int> possibleDdrFrequency)
    {
        PossibleDdrFrequency = possibleDdrFrequency;
    }

    public IList<int> PossibleDdrFrequency { get; private set; }

    public MotherboardChipset Clone()
    {
        return new MotherboardChipset(
            PossibleDdrFrequency);
    }

    public MotherboardChipset SetMotherboardChipsetPossibleDdrFrequency(IList<int> possibleDdrFrequency)
    {
        MotherboardChipset chipsetClone = Clone();

        chipsetClone.PossibleDdrFrequency = possibleDdrFrequency;

        return chipsetClone;
    }
}