using MlScoringService.Models;

namespace MlScoringService.Services;

public interface IScoringService
{
    ScoreResponse Score(ScoreRequest request);
}
