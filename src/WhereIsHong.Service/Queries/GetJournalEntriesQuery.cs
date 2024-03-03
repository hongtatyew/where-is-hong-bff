using MediatR;
using Microsoft.Extensions.Options;

namespace WhereIsHong.Services.Queries;

public class GetJournalEntriesQuery : IRequest<List<JournalEntry>>
{
}

public class GetJournalEntriesQueryHandler(IJournalRepository _journalRepository, IOptions<WhereIsHongOptions> _options) : IRequestHandler<GetJournalEntriesQuery, List<JournalEntry>>
{
    public async Task<List<JournalEntry>> Handle(GetJournalEntriesQuery request, CancellationToken cancellationToken)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(_options.Value.JournalId, Guid.Empty);

        return await _journalRepository
            .GetEntriesAsync(_options.Value.JournalId, cancellationToken)
            .ConfigureAwait(false);
    }
}
