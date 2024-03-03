namespace WhereIsHong;

public interface IJournalRepository
{
    Task<List<JournalEntry>> GetEntriesAsync(Guid journalId, CancellationToken cancellationToken = default);
}
