using BLL.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITY.Entitis;
using System.Text.RegularExpressions;
using UI_UX_Dashboard_P1.Custom;
using BLL;

namespace UI_UX_Dashboard_P1.UI
{
    public partial class FrmTarjetaMedioPago : Form
    {
        Seccion seccion = Seccion.Instance;
        private int? _ClienteId { get; set; }
        MediosPagosAdmin ln = new MediosPagosAdmin();
        public FrmTarjetaMedioPago(int? idCiente = 0)
        {
            InitializeComponent();
            _ClienteId = idCiente;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string tc = maskedTextBoxCardNumber.Text.Replace("_", "");
                string fex = maskedTextBoxExpiryDate.Text.Replace("_", "");
                string cvc = maskedTextBoxCVV.Text.Replace("_", "");


                string[] partes = fex.Split('-');
                int Mes = int.Parse(partes[0]);
                int Year = int.Parse(partes[1]) + 2000;


                if (Mes > 12)
                {
                    Helpers.ShowTypeError("El mes ingresado para la tarjeta no es válido. Un calendario solo tiene 12 meses.", "Error de Validación");
                    maskedTextBoxExpiryDate.Clear();
                    return;
                }

                //textBoxCardHolder.Text
                if (ValidarFormulario())
                {
                    ln.GuardarTarjetaClientes(new ClienteTarjeta()
                    {
                        Id = 0,
                        ClienteId = _ClienteId,
                        Tarjetahabiente = textBoxCardHolder.Text,
                        Tarjeta = Tools.Encode(tc),
                        TarjetaReferencia = tc,
                        FechaCaducidad = new DateTime(Year, Mes, DateTime.DaysInMonth(Year, Mes)),
                        Cvc = int.Parse(cvc),
                        Domisilida = checkBox_Domiciliar.Checked,
                        Usuario = seccion.UsuarioID
                    });

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Helpers.ShowError("No se pudo agregar la tarjeta error en el metodo:btnSubmit_Click ", ex);
            }
        }

        public bool ValidarFormulario()
        {
            bool result = true;
            StringBuilder mensajeError = new StringBuilder();
            string tc = maskedTextBoxCardNumber.Text.Replace("_", "");
            string fex = maskedTextBoxExpiryDate.Text.Replace("_", "").Replace("-", "");
            string cvc = maskedTextBoxCVV.Text.Replace("_", "");
            // Validación del número de tarjeta
            if (string.IsNullOrWhiteSpace(tc))
            {
                mensajeError.AppendLine("\n■ Digite su número de tarjeta.");
                result = false;
            }

            // Validación del nombre del tarjetahabiente
            if (string.IsNullOrWhiteSpace(textBoxCardHolder.Text))
            {
                mensajeError.AppendLine("\n■ Digite el nombre del tarjetahabiente.");
                result = false;
            }
            // Validación de fecha de caducidad
            if (string.IsNullOrWhiteSpace(fex))
            {
                mensajeError.AppendLine("\n■ Digite una fecha de caducidad válida.");
                result = false;
            }
            // Validación del CVC
            if (string.IsNullOrWhiteSpace(cvc))
            {
                mensajeError.AppendLine("\n■ Digite un código de seguridad (CVC) válido de 3 dígitos.");
                result = false;
            }

            //// Validación del campo domiciliada (opcional)
            //if (!checkBox_Domiciliar.Checked)
            //{
            //    mensajeError.AppendLine("\n■ Debe indicar si la tarjeta será domiciliada.");
            //    result = true;
            //}
            // Si hubo errores, mostrar los mensajes 
            if (mensajeError.Length > 0)
            {
                MessageBox.Show(mensajeError.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private void FrmTarjetaMedioPago_Load(object sender, EventArgs e)
        {
            // Crear una instancia de ToolTip
            ToolTip toolTip = new ToolTip();

            // Configurar propiedades del ToolTip
            toolTip.ToolTipTitle = "¿Qué significa domiciliar?";
            toolTip.IsBalloon = true; // Mostrar el estilo globo
            toolTip.AutoPopDelay = 5000; // Duración del mensaje en milisegundos
            toolTip.InitialDelay = 500; // Retraso antes de aparecer
            toolTip.ReshowDelay = 200; // Retraso entre repetición
            toolTip.ShowAlways = true; // Mostrar siempre, incluso si el control no está activo

            // Asignar el mensaje al CheckBox
            toolTip.SetToolTip(checkBox_Domiciliar,
                "Esta opción permite guardar y domiciliar los pagos\n sin necesidad de registrar la tarjeta nuevamente.");
        }
    }
}
