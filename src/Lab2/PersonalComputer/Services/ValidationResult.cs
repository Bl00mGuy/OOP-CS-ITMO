namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

public class ValidationResult
{
    public ValidationResult(bool isValid, AnalizatorStatus status)
    {
        Valid = isValid;
        Status = status;
    }

    public bool Valid { get; private set; }
    public AnalizatorStatus Status { get; private set; }
    public AnalizatorStatus? RecommendedStatus { get; private set; }

    public void SetValid(bool isValid)
    {
        Valid = isValid;
    }

    public void SetAnalysisStatus(AnalizatorStatus status)
    {
        Status = status;
    }

    public void SetRecommendedStatus(AnalizatorStatus recommendedStatus)
    {
        RecommendedStatus = recommendedStatus;
    }
}