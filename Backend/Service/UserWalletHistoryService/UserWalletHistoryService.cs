using test_binance_api.Models.DTOs.User;
using test_binance_api.Models;
using test_binance_api.Repository.HistoryRepository;
using test_binance_api.Repository.UserRepository;
using AutoMapper;

namespace test_binance_api.Service.UserWalletHistoryService
{
    public class UserWalletHistoryService : IUserWalletHistoryService
    {
        IUserRepository _userRepository;
        IHistoryRepository _historyRepository;
        IMapper _mapper;

        public UserWalletHistoryService(IUserRepository userRepository, IHistoryRepository historyRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _historyRepository = historyRepository;
            _mapper = mapper;

        }

        public async Task<UserDTO> CreateAsync(UserCreateDTO user)
        {
            var newUser = _mapper.Map<User>(user);
            var newHistory = new History();
            await _historyRepository.CreateAsync(newHistory);
            newUser.IdHistory = newHistory.Id;
            newUser.History = newHistory;
            await _userRepository.CreateAsync(newUser);
            return _mapper.Map<UserDTO>(newUser);
        }

    }
}
