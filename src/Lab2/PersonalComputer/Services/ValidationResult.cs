namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

public record ValidationResult(bool Valid, AnalizatorStatus Status, RecommendationStatus? Recommendation);