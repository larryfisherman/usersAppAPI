using AutoMapper;
using rekrutacja.Entities;
using rekrutacja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rekrutacja.Services
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public int Create(User dto);
        public void Delete(int id);
        public void Update(int id, User dto);



    }
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _dbContext.Users.ToList();
            var result = _mapper.Map<List<User>>(users);

            return result;
        }

        public int Create(User dto)
        {
            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public void Update(int id, User dto)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == id);
            
            user.Name = dto.Name;
            user.Surname = dto.Surname;

            _dbContext.SaveChanges();
        }

    }
}

   
