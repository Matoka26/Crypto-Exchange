using AutoMapper;
using test_binance_api.Models;
using test_binance_api.Models.DTOs;
using test_binance_api.Models.DTOs.User;

namespace test_binance_api.Helpers
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<User, UserCreateDTO>();
            CreateMap<UserCreateDTO, User>();

            CreateMap<User, UserUpdateDTO>();
            CreateMap<UserUpdateDTO, User>();

            CreateMap<User, UserSignUpDTO>();
            CreateMap<UserSignUpDTO, User>();

            CreateMap<Coin, CoinDTO>();
            CreateMap<CoinDTO, Coin>();
        }

    }
}
