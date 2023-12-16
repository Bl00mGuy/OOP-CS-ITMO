using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;

public class MotherboardBios : IBiOs
{
    public MotherboardBios(int version, IList<string> supportedCpus)
    {
        BiosVersion = version;
        SupportedCpus = supportedCpus;
    }

    public int BiosVersion { get; private set; }
    public IList<string> SupportedCpus { get; private set; }

    public MotherboardBios Clone()
    {
        return new MotherboardBios(
            BiosVersion,
            SupportedCpus);
    }

    public MotherboardBios SetMotherboardBiosVersion(int biosVersion)
    {
        MotherboardBios biosClone = Clone();

        biosClone.BiosVersion = biosVersion;

        return biosClone;
    }

    public MotherboardBios SetMotherboardBiosSupportedCpus(IList<string> supportedCpus)
    {
        MotherboardBios biosClone = Clone();

        biosClone.SupportedCpus = supportedCpus;

        return biosClone;
    }
}