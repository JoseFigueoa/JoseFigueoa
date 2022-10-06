using Gestor2._0.Data.DB_BASE;
using Gestor2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Services
{
    public class UsuarioServices
    {

        private readonly GestorDeActasNetContext _context;

        public UsuarioServices(GestorDeActasNetContext context)
        {
            _context = context;
        }

        public Usuario ObtenerUsuarioLogin(Usuario _usuario)
        {

            return (from _user in _context.Usuarios
                    where _user.Usuario == _usuario.usuario
                    where _user.PasswordEncrypt == _usuario.password
                    select new Usuario 
                        { 
                            usuario = _user.Usuario, 
                            id = _user.Id, 
                            correo = _user.Correo,                          
                        }
                    ).FirstOrDefault();


        }

        public bool VerificarPassword(string password, string passwordEncript)
        {
            if (password == passwordEncript)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
