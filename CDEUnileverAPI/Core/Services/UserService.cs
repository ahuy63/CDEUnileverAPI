using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using NuGet.Common;

namespace CDEUnileverAPI.Core.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }
        public async Task<User> GetUserDetails(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }
        public async Task<ApiResponse> AddUser(User user)
        {
            //var userExist = _context.Users.FirstOrDefault(x => x.Email == userDTO.Email);
            var userExist = _unitOfWork.UserRepository.GetByEmail(user.Email);
            if (userExist != null)
            {

                return new ApiResponse
                {
                    Result = false,
                    Message = "Email is already exist"
                };
            }
            try
            {
                user.Password = RandomString(10);
                await _unitOfWork.UserRepository.Add(user);
                await _unitOfWork.CommitAsync();
                SendEmail(user.Email, user.Password);
                return new ApiResponse
                {
                    Result = true,
                    Message = "Please check Email to get password and change password",
                };
            }
            catch (Exception)
            {
                return new ApiResponse
                {
                    Result = false,
                    Message = "Please check Email to get password and change password",
                };
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetById(id);
                if (user != null)
                {
                    if (await _unitOfWork.UserRepository.Delete(user))
                    {
                        await _unitOfWork.CommitAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(int id, User user)
        {
            try
            {
                var existingUser = await _unitOfWork.UserRepository.GetById(id);
                if (existingUser != null)
                {
                    existingUser.FullName = user.FullName;
                    existingUser.Phone = user.Phone;
                    existingUser.Address = user.Address;
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserPassword(int id, string newPassword)
        {
            try
            {
                var existingUser = await _unitOfWork.UserRepository.GetById(id);
                if (existingUser != null)
                {
                    existingUser.Password = newPassword;
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserArea(User user, int? areaId)
        {
            try
            {
                if (user != null)
                {
                    user.AreaId = areaId;
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void SendEmail(string toEmail, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ahuy.hah@gmail.com"));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = "Mật khẩu cho tài khoản";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = "Mật khẩu tạm thời: \n" + body + " \n Vui lòng thay đổi mật khẩu"
            };

            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("ahuy.hah@gmail.com", "ckystazencahpvnt");
            smtp.Send(email);
            smtp.Disconnect(true);
            smtp.Dispose();
        }

        public async Task<IEnumerable<User>> GetUserByAreaId(int areaId)
        {
            return await _unitOfWork.UserRepository.GetByAreaIdAsync(areaId);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _unitOfWork.UserRepository.GetByEmail(email);
        }
    }
}
