
using MailFlow.BLL.Interfaces;
using MailFlow.BLL.DTOs;
using MailFlow.DAL;
using MailFlow.DAL.Interfaces;
using MailFlow.UTILITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using MailFlow.BLL.Validations;
using AutoMapper;

namespace MailFlow.BLL.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IGenericRepository<Usuario> _genericRepository;
        private IMapper _mapper;
        public UsuarioService(IGenericRepository<Usuario> genericRepository, IMapper mapper) 
        {

            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<LoginResult> VerifyCredentialsAsync(LoginRequest session)
        {
            try
            {

                var usuario = await _genericRepository.GetAsync(x=> x.Email == session.Email);

                if (usuario is null)
                {
                    return LoginResult.UserNotFound;

                }
                else if (usuario.Password != Encripting.SHA256(session.Password))
                {
                    return LoginResult.Invalid;
                }
                else return LoginResult.Success;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UsuarioResponse> RegisterAsync( UsuarioRegistoRequest registo)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(registo);
                await _genericRepository.CreateAsync(usuario);
                return _mapper.Map<UsuarioResponse>(usuario);

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
