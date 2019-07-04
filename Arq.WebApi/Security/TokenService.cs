using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Arq.Data;
using Arq.Domain;
using Arq.WebApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Arq.WebApi.Security
{
    public class TokenService
    {
        TokenSettings _settings;
        private GenericRepository<Student> _studentsRepository;

        public TokenService(
            TokenSettings settings,
            GenericRepository<Student> studentsRepository)
        {
            _settings = settings;
            _studentsRepository = studentsRepository;
        }

        public async Task<TokenViewModel> GenerateTokenAsync(string username, string password)
        {
            var student = await _studentsRepository.GetQueryable().SingleOrDefaultAsync(s => s.Username == username);

            if (student == null)
                throw new ArgumentException(nameof(username));

            if (!student.ValidatePassword(password))
                throw new ArgumentException(nameof(password));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(_settings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(DefaultClaims.Username, student.Username),
                    new Claim(DefaultClaims.UserId, student.Id.ToString())
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddYears(7),
                Audience = _settings.Audience,
                Issuer = _settings.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var viewModel = new TokenViewModel
            {
                Token = tokenHandler.WriteToken(token)
            };

            return viewModel;
}
    }
}