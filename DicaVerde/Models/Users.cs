using Microsoft.AspNetCore.Identity;

namespace DicaVerde.Models
{
    public class User : IdentityUser
    {
        // NÃO declarar Id nem Email, pois já existem na base IdentityUser

        // Propriedades adicionais personalizadas
        public string NomeCompleto { get; set; }

        public string Perfil { get; set; } // Ex: "Administrador", "Usuario", "GoogleUser"

    }
}
