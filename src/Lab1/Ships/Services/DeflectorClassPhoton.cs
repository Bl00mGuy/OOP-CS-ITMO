namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class DeflectorClassPhoton
{
    private int _remainingAntimatterFlares = 3;

    public bool DeflectObstacle()
    {
        if (_remainingAntimatterFlares > 0)
        {
            _remainingAntimatterFlares -= 1;

            return true;
        }

        return false;
    }
}