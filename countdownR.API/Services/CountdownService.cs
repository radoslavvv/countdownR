//using countdownR.API.Common;
//using countdownR.API.Entities;
//using countdownR.API.Repositories.Contracts;

//namespace countdownR.API.Services;

//public class CountdownService
//{
//    private readonly ICountdownRepository _repository;

//    public CountdownService(ICountdownRepository repository)
//    {
//        _repository = repository;
//    }

//    public async Task<ServiceResponse> GetCountdowns()
//    {
//        IEnumerable<Countdown> countdowns = await _repository.GetCountdownsAsync();

//        return new ServiceResponse(countdowns);
//    }
//}
