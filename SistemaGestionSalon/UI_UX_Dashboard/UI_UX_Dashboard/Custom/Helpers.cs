using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_UX_Dashboard_P1.Custom
{
    public static class Helpers
    {

        public static void ShowValidacion(string message)
        {
            MessageBox.Show($"Campo {message} es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public static void ShowError(string message, Exception ex = null)
        {
            string errorMessage = message;

            // Agregar el mensaje de excepción si se proporciona
            if (ex != null)
            {
                errorMessage += $"\n\nDetalles del error:\n{ex.Message}";
            }

            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Opcional: Loggear el error en un archivo o sistema de registro
            //LogError(message, ex); 
        }


        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Método para mostrar mensajes de advertencia


        public static void ShowTypeError(string message,string type)
        {
            MessageBox.Show(message, type, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Método para mostrar mensajes de confirmación
        public static DialogResult ShowConfirmation(string message)
        {
            return MessageBox.Show(message, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        // Método privado para registrar errores (opcional)
        private static void LogError(string message, Exception ex)
        {
            // Aquí puedes implementar la lógica para registrar errores en un archivo o sistema de registro
            // Por ejemplo:
            // File.AppendAllText("log.txt", $"{DateTime.Now}: {message}\n{ex?.ToString()}\n\n");
        }

        public static string FormatException(Exception eex, string FullName = "", string MethodExceptionName = "")
        {
            var body = "StacTrace:{0}";
            body += Environment.NewLine + "InnerExceptin:{1}";
            body += Environment.NewLine + "Error:{2}";
            body += Environment.NewLine + "Usuario:{3}";
            body += Environment.NewLine + "Metodo:{4}";
            string rBody = string.Format(body, eex.StackTrace, eex.InnerException, eex.Message, FullName, MethodExceptionName);
            return rBody;
        }



        public static void CargarDatosPaginados<T>(List<T> items, int currentPage, int pageSize, BindingSource bindingSource, Action actualizarEstadoBotones)
        {
            int totalRecords = items.Count;
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Obtener el subconjunto de datos para la página actual
            var paginatedData = items
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            bindingSource.DataSource = paginatedData;

            // Llamar al método que actualiza el estado de los botones, si se proporciona
            actualizarEstadoBotones?.Invoke();
        }


    }
}
