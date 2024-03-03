using System.Net.Http.Json;

namespace WhereIsHong.WishClient;

public class JournalRepository(HttpClient _httpClient) : IJournalRepository
{
    public async Task<List<JournalEntry>> GetEntriesAsync(Guid journalId, CancellationToken cancellationToken = default)
    {
        var getJournalBriefResponse = await _httpClient
            .GetFromJsonAsync<List<GetJournalEntriesResponse>>($"journals/{journalId:N}/entries", cancellationToken)
            .ConfigureAwait(false) ?? [];

        var journalEntries = new List<JournalEntry>();
        foreach (var entry in getJournalBriefResponse)
        {
            var detailEntry = await _httpClient
                .GetFromJsonAsync<JournalEntry>($"journals/{journalId:N}/entries/{entry.Id}", cancellationToken)
                .ConfigureAwait(false);

            if (detailEntry is not null) journalEntries.Add(detailEntry);
        }
        
        return [.. journalEntries.OrderByDescending(x => x.Created)];
    }
}
