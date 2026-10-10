using System.Diagnostics.Metrics;

namespace Identity.Infrastructure.Observability;

/// <summary>Security metrics of the identity service (meter <c>Store.Identity</c>).</summary>
internal static class IdentityMetrics
{
    public const string MeterName = "Store.Identity";

    private static readonly Meter Meter = new(MeterName);

    private static readonly Counter<long> Logins = Meter.CreateCounter<long>("store.identity.logins",
        description: "Login attempts; outcome = success | unknown_user | inactive | invalid_credentials | locked_out.");

    public static void LoginAttempt(string outcome) =>
        Logins.Add(1, new KeyValuePair<string, object?>("outcome", outcome));
}
