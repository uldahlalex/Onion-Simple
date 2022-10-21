using Application.DTOs;

namespace Application.Interfaces;

public interface IAuthenticationService
{
    public string Register(LoginAndRegisterDTO dto);
    public string Login(LoginAndRegisterDTO dto);
}