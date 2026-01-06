using MailFlow.BE.DTOs;
using MailFlow.BLL.Interfaces;
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

namespace MailFlow.BLL
{
    public class UsuaarioService : IUsuarioService
    {
        private IGenericRepository<Usuario> _genericRepository;
        public UsuaarioService(IGenericRepository<Usuario> genericRepository) {


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

        public async Task Registrar(UsuarioRegistoRequest registo)
        {
            try
            {
               


            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
