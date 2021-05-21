using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoPr1.forms;

namespace ProyectoPr1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Instanciamos el formulario de login
            LoginForm loginForm = new LoginForm();
            //Instanciamos el menu principal
            MenuForm menu = new MenuForm();
            //Declaramos e inicializamos variable resultado que nos servir� como bandera para el bucle
            DialogResult resultado = DialogResult.Cancel;
            //Agrega usuario admin a la lista de empleados del menu
            menu.addEmpleado(loginForm.getCurrentUser());
            do
            {
                //Cada vez que inicia un nuevo ciclo, el resultado debe volver a su valor original
                resultado = DialogResult.Cancel;
                //Resfresca el listado de empleados en el login para validar
                loginForm.setEmpleados(menu.GetEmpleados());
                //Si inicia sesi�n exitosamente el resultado del dialogo ser� OK
                DialogResult resultadoLogin = loginForm.ShowDialog();
                if(resultadoLogin == DialogResult.OK)
                {
                    //Si el resultado es Ok entonces mostramos menu principal
                    // Asignamos el usuario que acaba de iniciar sesi�n
                    menu.setUsername(loginForm.getCurrentUser().Nombre);
                    //Si el resultado del menu es Cancel salimos del aplicativo
                    //Si el resultado es No entonces significa que el usuario cerr� sesi�n
                    //Si cerr� sesi�n debemos mostrar el men� nuevamente
                    resultado =  menu.ShowDialog();

                }
                else
                {
                    /*si el usuario cerr� la ventana de login el resultado del dialogo ser�
                      Cancel, entonces cerramos el aplicativo  */
                    Application.Exit();
                }
                

                /*Si el usuario cerr� el men� principal, el restulado ser�
                  Cancel entonces el aplicativo finaliza  */
            } while (resultado != DialogResult.Cancel);

        }
    }
}
