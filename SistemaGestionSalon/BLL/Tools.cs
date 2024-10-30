using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Tools
    {
        public static string GenerarNombreUsuario(string nombreCompleto)
        {
            // Separar el nombre completo en partes
            var partes = nombreCompleto.Split(' ');

            // Tomar la primera inicial y el apellido o una combinación de nombres
            string nombreUsuario;

            if (partes.Length > 1)
            {
                // Obtener la primera inicial y el primer apellido
                string inicial = partes[0].Substring(0, 1).ToLower(); // Inicial del primer nombre
                string apellido = partes[partes.Length - 1].ToLower(); // Último apellido

                // Combinar para formar el nombre de usuario
                nombreUsuario = $"{inicial}{apellido}";
            }
            else
            {
                // Si solo hay un nombre, usarlo directamente
                nombreUsuario = partes[0].ToLower();
            }

            return nombreUsuario;
        }

    }
}
