using AutoMapper;
using Demo.Entities;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AppContext();

            var repo = new Repository<User>(context);

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<User, UserDTO>()
                    .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name)));

            repo.GetAsync<UserDTO>(u => u.Id == 1, config).GetAwaiter().GetResult();

            Console.WriteLine("Hello World!");
        }
    }
}
