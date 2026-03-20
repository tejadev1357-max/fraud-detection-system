using RuleEngineService.Models;
using StackExchange.Redis;

namespace RuleEngineService.Services;

public class RuleEngineServiceImpl : IRuleEngineService
{
    private readonly IConnectionMultiplexer _redis;
    private readonly ILogger<RuleEngineServiceImpl> _logger;
    private readonly IConfiguration _configuration;

    private const string BlocklistKey = "fraud:blocklist:accounts";
    private const decimal DefaultAmountThreshold = 10000m;

    public RuleEngineServiceImpl(
        IConnectionMultiplexer redis,
        ILogger<RuleEngineServiceImpl> logger,
        IConfiguration configuration)
    {
        _redis = redis;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<EvaluateResponse> EvaluateAsync(EvaluateRequest request)
    {
        var triggeredRules = new List<string>();
        var db = _redis.GetDatabase();

        // Rule 1: Amount threshold check
        var threshold = _configuration.GetValue<decimal>("Rules:AmountThreshold", DefaultAmountThreshold);
        if (request.Amount > threshold)
        {
            triggeredRules.Add($"AmountThreshold: Transaction amount {request.Amount} exceeds threshold {threshold}");
            _logger.LogWarning("Amount threshold rule triggered for account {AccountId}, amount {Amount}",
                request.AccountId, request.Amount);
        }

        // Rule 2: Account blocklist check (stored in Redis set)
        bool isBlocklisted = await db.SetContainsAsync(BlocklistKey, request.AccountId);
        if (isBlocklisted)
        {
            triggeredRules.Add($"Blocklist: Account {request.AccountId} is on the blocklist");
            _logger.LogWarning("Blocklist rule triggered for account {AccountId}", request.AccountId);
        }

        var isFraudulent = triggeredRules.Count > 0;
        var riskLevel = triggeredRules.Count switch
        {
            0 => "Low",
            1 => "Medium",
            _ => "High"
        };

        return new EvaluateResponse
        {
            IsFraudulent = isFraudulent,
            RiskLevel = riskLevel,
            TriggeredRules = triggeredRules,
            EvaluatedAt = DateTime.UtcNow
        };
    }
}
