﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// User service implementation
    /// </summary>
    public class UserService : BaseService<User, UserDto, UserCreationDto, UserUpdateDto, Guid>, IUserService
    {
        #region Declaration

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) : base(userRepository, unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public Task<string> Login(LoginDto loginDto)
        {
            var token = _userRepository.Login(loginDto.Email, loginDto.Password);

            return token;
        }

        public new async Task<UserDto> InsertAsync(UserCreationDto userCreationDto)
        {
            var user = MapCreationDtoToEntity(userCreationDto);

            await _userRepository.CreateUser(user, userCreationDto.Password);

            var createdUserDto = MapEntityToDto(user);

            return createdUserDto;
        }

        #region Mapping

        public override User MapCreationDtoToEntity(UserCreationDto? userCreationDto)
        {
            return _mapper.Map<User>(userCreationDto);
        }

        public override UserDto MapEntityToDto(User user)
        {
            return _mapper.Map<UserDto>(user);
        }

        public override User MapUpdateDtoToEntity(UserUpdateDto userUpdateDto)
        {
            return _mapper.Map<User>(userUpdateDto);
        }

        #endregion

        #endregion
    }
}