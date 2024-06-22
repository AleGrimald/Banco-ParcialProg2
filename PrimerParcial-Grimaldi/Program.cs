using System;

namespace PrimerParcial_Grimaldi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bandera = true;
            string opc;

            do
            {
                Console.Clear();
                Console.WriteLine("\t BIENVENIDO ADMIN");
                Console.WriteLine(" 1- Crear Usuario");
                Console.WriteLine(" 2- Listar Usuarios");
                Console.WriteLine(" 3- Buscar Usuario por Numero de Cuenta");
                Console.WriteLine(" 4- Modificar Usuario");
                Console.WriteLine(" 5- Eliminar Usuario");
                Console.WriteLine(" 6- Realizar Deposito");
                Console.WriteLine(" 7- Realizar Extraccion");
                Console.WriteLine(" 8- Aplicar Intereses");
                Console.WriteLine(" 9- Salir");
                Console.Write("Seleccione una opcion: ");
                opc = Console.ReadLine().ToLower();
                Console.Clear();

                switch (opc)
                {
                    case "1":
                        CrearUsuario();
                        break;
                    case "2":
                        MostrarUsuario();
                        break;
                    case "3":
                        BuscarUsuario();
                        break;
                    case "4":
                        ModificarUsuario();
                        break;
                    case "5":
                        EliminarUsuario();
                        break;
                    case "6":
                        Depositar();
                        break;
                    case "7":
                        Extraer();
                        break;
                    case "8":
                        AplicarIntereses();
                        break;
                    case "9":
                        bandera = false;
                        break;

                    default:
                        break;
                }
                Console.ReadKey();

            } while (bandera);


        }

        public static void CrearUsuario()
        {
            Personas objPersona = new Personas();
            string nombre, apellido, direccion, email;
            long dni, telefono;
            decimal saldo;
            
            
            try
            {
                long nroCuenta;
                if (objPersona.GetUltimoNroCuenta().Length == 0)
                {
                    nroCuenta = 1000;
                }
                else
                {
                    nroCuenta = objPersona.GetUltimoNroCuenta()[objPersona.GetUltimoNroCuenta().Length - 1] + 1;
                }
                Console.WriteLine("Ingrese el apellido");
                apellido = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre");
                nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el dni");
                dni = long.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el direccion");
                direccion = Console.ReadLine();
                Console.WriteLine("Ingrese el telefono");
                telefono = long.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el email");
                email = Console.ReadLine();
                Console.WriteLine("Ingrese el saldo inicial");
                saldo = decimal.Parse(Console.ReadLine());

                objPersona = new Personas(apellido, nombre, email, direccion, dni, telefono, saldo, nroCuenta);
                objPersona.CrearUsuario();

                Console.WriteLine("Alta Exitosa !!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Datos Incorrectos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MostrarUsuario()
        {
            Personas objPersona = new Personas();
            dynamic[] arrDatos = objPersona.MostrarUsuarios();

            string[] etiquetas = { "Apellido", "Nombre", "Dni", "Direccion", "Telefono", "Email", "Saldo", "Numero de Cuenta" };

            for (int i = 0; i < arrDatos.Length; i++)
            {
                Console.WriteLine($" Cliente: {i}");
                for (int j = 0; j < 8; j++)
                {
                    Console.WriteLine($"\t{etiquetas[j]}: {arrDatos[i][j]}");
                }
                Console.WriteLine("--------------------------------------------");
            }


        }

        public static void BuscarUsuario()
        {
            long nroCuenta;
            string[] etiquetas = { "Apellido", "Nombre", "Dni", "Direccion", "Telefono", "Email", "Saldo", "Numero de Cuenta" };

            try
            {
                Console.WriteLine("Ingrese el Numero de Cuenta");
                nroCuenta = long.Parse(Console.ReadLine());

                Personas objPersona = new Personas(nroCuenta);
                string[] datosEncontrados = objPersona.BuscarUsuario();

                Console.Clear();
                Console.WriteLine($" Cliente {nroCuenta}");
                for (int i = 0; i < etiquetas.Length; i++)
                {
                    Console.WriteLine($"\t{etiquetas[i]}: {datosEncontrados[i]}");
                }

                Console.WriteLine("\nPrecione una tecla para volder al menu principal.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ModificarUsuario()
        {
            try
            {
                Console.WriteLine("Ingrese el Numero de Cuenta");
                Personas objPersona = new Personas(long.Parse(Console.ReadLine()));

                string[] datosEncontrados = objPersona.BuscarUsuario();
                string apellido = datosEncontrados[0];
                string nombre = datosEncontrados[1];
                long dni = long.Parse(datosEncontrados[2]);
                string direccion = datosEncontrados[3];
                long telefono = long.Parse(datosEncontrados[4]);
                string email = datosEncontrados[5];
                decimal saldo = decimal.Parse(datosEncontrados[6]);
                long nroCuenta = long.Parse(datosEncontrados[7]);

                Console.WriteLine("Que dato desea modificar?");
                Console.WriteLine(" 1 - Apellido");
                Console.WriteLine(" 2 - Nombre");
                Console.WriteLine(" 3 - Dni");
                Console.WriteLine(" 4 - Direccion");
                Console.WriteLine(" 5 - Telefono");
                Console.WriteLine(" 6 - Email");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Ingrese el apellido");
                        apellido = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Ingrese el nombre");
                        nombre = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Ingrese el dni");
                        dni = long.Parse(Console.ReadLine());
                        break;
                    case "4":
                        Console.WriteLine("Ingrese el direccion");
                        direccion = Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Ingrese el telefono");
                        telefono = long.Parse(Console.ReadLine());
                        break;
                    case "6":
                        Console.WriteLine("Ingrese el email");
                        email = Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Opcion Incorrecta.");
                        break;
                }

                objPersona = new Personas(apellido, nombre, email, direccion, dni, telefono, saldo, nroCuenta);
                objPersona.ModificarUsuario();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void EliminarUsuario()
        {
            int numCliente;
            
            try
            {
                MostrarUsuario();
                Console.WriteLine("Seleccione un numero de CLIENTE");
                numCliente = int.Parse(Console.ReadLine());

                Personas objPersona = new Personas(numCliente);
                objPersona.EliminarUsuario();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    
        public static void Depositar()
        {
            decimal saldoActual, deposito;
            long nroCuenta;

            try
            {
                Console.WriteLine("Ingrese el Numero de Cuenta");
                nroCuenta = long.Parse(Console.ReadLine());

                Personas objPersona = new Personas(nroCuenta);
                string[] datosEncontrados = objPersona.BuscarUsuario();
                saldoActual = decimal.Parse(datosEncontrados[6]);//Saldo Actual de el usuario solicitado

                Console.WriteLine("Ingrese el Monto que desea DEPOSITAR.");
                deposito = decimal.Parse(Console.ReadLine());

                objPersona.Saldo = saldoActual;
                objPersona.Deposito = deposito;
                objPersona.Depositar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Extraer()
        {
            decimal saldoActual, deposito;
            long nroCuenta;

            try
            {
                Console.WriteLine("Ingrese el Numero de Cuenta");
                nroCuenta = long.Parse(Console.ReadLine());

                Personas objPersona = new Personas(nroCuenta);
                string[] datosEncontrados = objPersona.BuscarUsuario();
                saldoActual = decimal.Parse(datosEncontrados[6]);//Saldo Actual de el usuario solicitado

                Console.WriteLine("Ingrese el Monto que desea DEPOSITAR.");
                deposito = decimal.Parse(Console.ReadLine());

                objPersona.Saldo = saldoActual;
                objPersona.Deposito = deposito;
                objPersona.Extraer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AplicarIntereses()
        {
            decimal interesAplicado,saldoActual;
            long nroCuenta;

            try
            {
                Console.WriteLine("Ingrese el Numero de Cuenta");
                nroCuenta = long.Parse(Console.ReadLine());

                Personas objPersona = new Personas(nroCuenta);
                string[] datosEncontrados = objPersona.BuscarUsuario();
                saldoActual = decimal.Parse(datosEncontrados[6]);

                Console.WriteLine("Ingrese el Interes anual que se aplicara.");
                interesAplicado = decimal.Parse(Console.ReadLine());

                objPersona.InteresAnual = interesAplicado;
                objPersona.Saldo = saldoActual;
                objPersona.Interes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
