using System;
using System.Linq;

namespace PrimerParcial_Grimaldi
{
    public class Personas : Banco
    {
        //Atributos
        private string apellido;
        private string nombre;
        private string email;
        private string direccion;
        private long dni;        
        private long telefono;
        private int nroCliente;
        private readonly Archivos objArchivo = new Archivos();

        //Encapsulamiento
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public long Dni { get => dni; set => dni = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        internal Archivos ObjArchivo { get => objArchivo;}
        public int NroCliente { get => nroCliente; set => nroCliente = value; }

        public Personas()
        {

        }

        public Personas(long _nroCuenta)
        {
            NroCuenta = _nroCuenta;
        }

        public Personas(int _nroCliente)
        {
            NroCliente = _nroCliente;
        }

        public Personas(string _apellido, string _nombre, string _email, string _direccion, long _dni, long _telefono, decimal _saldo, long _nroCuenta)
        {
            Apellido = _apellido;
            Nombre = _nombre;
            Email = _email;
            Direccion = _direccion;
            Dni = _dni;
            Telefono = _telefono;
            Saldo = _saldo;
            NroCuenta = _nroCuenta;
        }

        public void CrearUsuario()
        {
            dynamic[] datosCliente = {Apellido, Nombre, Dni, Direccion, Telefono, Email, Saldo, NroCuenta };
            ObjArchivo.EscribirArchivo(datosCliente);
        }

        public dynamic MostrarUsuarios()
        {
            string[] lineas = ObjArchivo.LeerArchivo();
            dynamic[] datos = new dynamic[lineas.Length];

            for (int i = 0; i < lineas.Length; i++)
            {
                datos[i] = lineas[i].Split('|');
            }
            return datos;
        }

        public string[] BuscarUsuario()
        {
            string[] lineas = ObjArchivo.LeerArchivo();
            dynamic[] arrAux = new dynamic[lineas.Length];

            for (int i = 0; i < lineas.Length; i++)
            {
                arrAux[i] = lineas[i].Split('|');
            }
            
            for (int i = 0; i < arrAux.Length; i++)
            {
                if (NroCuenta == long.Parse(arrAux[i][7]))
                {
                    return arrAux[i];
                }
            }
            return null;
        }

        public long[] GetUltimoNroCuenta()
        {
            string[] lineas = ObjArchivo.LeerArchivo();
            dynamic[] lineasProcesadas = new dynamic[lineas.Length];
            long[] arrNroCuenta = new long[lineas.Length];

            for (int i = 0; i < lineas.Length; i++)
            {
                lineasProcesadas[i] = lineas[i].Split('|');
            }

            for (int i = 0; i < lineasProcesadas.Length; i++)
            {
                arrNroCuenta[i] = long.Parse( lineasProcesadas[i][7]);
            }
            Array.Sort(arrNroCuenta);

            return arrNroCuenta;
        }

        public void ModificarUsuario()
        {
            dynamic[] arrDatos = MostrarUsuarios();
            dynamic[] arrDatosModif = { Apellido, Nombre, Dni, Direccion, Telefono, Email, Saldo, NroCuenta};

            try
            {
                for (int i = 0; i < arrDatosModif.Length; i++)
                {
                    if (long.Parse(arrDatos[i][7]) == NroCuenta)
                    {
                        arrDatos[i] = arrDatosModif;
                        ObjArchivo.ModificarArchivo(arrDatos);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void EliminarUsuario()
        {
            dynamic[] datos = MostrarUsuarios();

            datos = datos.Where(e => e != datos[NroCliente]).ToArray();
            ObjArchivo.ModificarArchivo(datos);
        }

    }
}
