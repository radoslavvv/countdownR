namespace countdownR.DataAccess.Configurations;

public class DatabaseConfiguration
{
    public bool UseInMemoryDatabase { get; set; }

    public string ConnectionString { get; set; } = string.Empty;
}
