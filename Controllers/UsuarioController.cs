using CraftAtHome.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace CraftAtHome.Controllers
{

    

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {

       

        [HttpGet("usuarios")]
        public IEnumerable<Usuario> Get()
        {
            return GetUsuarios();
        }



        [HttpPost("usuarios")]
        public string InsertarUsuario(Usuario usuario) {
            try
            {
                string password = cifrarContraseña(usuario.password);
                usuario.password = password;

                using (var context = new ArticleContext())
                {

                    if (verificaUsuario(usuario))
                    {
                        var users = usuario;
                        context.Usuario.Add(users);
                        context.SaveChanges();
                        return JsonSerializer.Serialize(usuario);

                    }
                    else {


                        return JsonSerializer.Serialize("El usuario ya se encuentra registrado");
                    }
                    
                }
            }
            catch (Exception e)
            {
                return JsonSerializer.Serialize(e.Message);
            }
        }

        private bool verificaUsuario(Usuario usuario)
        {
            using (var context = new ArticleContext())
            {

                Usuario user = context.Usuario.Where(m => m.email == usuario.email).SingleOrDefault();

                if (user != null)
                {
                    return false;
                }
                else {

                    return true;

                }
            }


        }

        private string cifrarContraseña(string password)
        {
            string codigocontraseña = "";
            byte[] byteArrayPassword = Encoding.Default.GetBytes(password);
            SHA512Managed algoritmoEncriptado = new SHA512Managed();
            byte[] codigoHashByteArray = algoritmoEncriptado.ComputeHash(byteArrayPassword);
            codigocontraseña = BitConverter.ToString(codigoHashByteArray);
            algoritmoEncriptado.Clear();
            return codigocontraseña;
        }

        private List<Usuario> GetUsuarios() {
            List<Usuario> listaUsuarios = new List<Usuario>();
            using (var context = new ArticleContext())
            {
                listaUsuarios = context.Usuario.ToList();
            }
            return listaUsuarios;
        }
    }
}
