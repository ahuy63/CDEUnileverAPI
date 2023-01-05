﻿using AutoMapper;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly CDEUnileverDbContext _context;
        public readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthenticationController(CDEUnileverDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var userExist = _context.Users.FirstOrDefault(x => x.Email == userDTO.Email);
                if (userExist != null)
                {
                    return BadRequest(new ApiResponse
                    {
                        Result = false,
                        Message = "Email is already exist"
                    });
                }
                try
                {
                    //var newUser = new IdentityUser();
                    var newUser = _mapper.Map<User>(userDTO);
                    newUser.Password = RandomString(10);
                    _context.Add(newUser);
                    _context.SaveChanges();
                    SendEmail(newUser.Email, newUser.Password);
                    var token = GenerateJwtToken(newUser);
                    return Ok(new ApiResponse
                    {
                        Result = true,
                        Message = "Please check Email to get password and change password",
                        Token = token
                    });
                }
                catch (Exception)
                {
                    return BadRequest("Server Error");
                }
            }
            return BadRequest();
        }


        [Route("Login")]
        [HttpPost]
        public IActionResult Login(UserLoginDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.Email == userDTO.Email && u.Password == userDTO.Password);
                if (user != null)
                {
                    return Ok(new ApiResponse
                    {
                        Result = true,
                        Message = "Success",
                        Token = GenerateJwtToken(user)
                    });
                }
            }
            return BadRequest(new ApiResponse
            {
                Result = false,
                Message = "Wrong Credential"
            });
        }

        //[HttpPost]
        //public IActionResult SendMail(string email)
        //{
        //    SendEmail(email, RandomString(10));
        //    return Ok();
        //}
        private string GenerateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);  
            var tokenDecriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Email", user.Email),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("TokenId", Guid.NewGuid().ToString())

                    //role
                }),
                Expires = DateTime.UtcNow.AddSeconds(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = jwtTokenHandler.CreateToken(tokenDecriptor);
            return jwtTokenHandler.WriteToken(token);
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
                Text = "Mật khẩu tạm thời: \n"+body+"\nVui lòng thay đổi mật khẩu"
            };

            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("ahuy.hah@gmail.com", "ckystazencahpvnt");
            smtp.Send(email);
            smtp.Disconnect(true);
            smtp.Dispose();
        }
    }
}
