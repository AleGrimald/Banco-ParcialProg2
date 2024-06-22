using System;

namespace PrimerParcial_Grimaldi
{
    public class Banco //HERENCIA
    {
        private long nroCuenta;
        private decimal saldo;
        private decimal interesAnual;
        private decimal deposito;

        //--------------------ENCAPSULAMIENTO
        public decimal Saldo { get => saldo; set => saldo = value; }
        public decimal InteresAnual { get => interesAnual; set => interesAnual = value; }
        public long NroCuenta { get => nroCuenta; set => nroCuenta = value; }
        public decimal Deposito { get => deposito; set => deposito = value; }

        //----------------------CONSTRUCTORES
        public Banco() 
        { 

        }

        //------------------------METODOS
        public void Depositar()
        {
            Personas objPersona = new Personas(nroCuenta);
            string[] datosEncontrados = objPersona.BuscarUsuario();

            if (deposito > 0)
            {
                Saldo += Deposito;
            }
            else
            {
                Console.WriteLine("Ingresa un monto valido");
            }


            string apellido = datosEncontrados[0];
            string nombre = datosEncontrados[1];
            long dni = long.Parse(datosEncontrados[2]);
            string direccion = datosEncontrados[3];
            long telefono = long.Parse(datosEncontrados[4]);
            string email = datosEncontrados[5];
            nroCuenta = long.Parse(datosEncontrados[7]);

            objPersona = new Personas(apellido, nombre, email, direccion, dni, telefono, Saldo, nroCuenta);
            objPersona.ModificarUsuario();
        }

        public void Extraer()
        {
            Personas objPersona = new Personas(nroCuenta);
            string[] datosEncontrados = objPersona.BuscarUsuario();

            if (deposito > 0 && Saldo>=Deposito)
            {
                Saldo -= Deposito;
            }
            else
            {
                Console.WriteLine("Ingresa un monto valido. O no tiene saldo suficiente");
            }


            string apellido = datosEncontrados[0];
            string nombre = datosEncontrados[1];
            long dni = long.Parse(datosEncontrados[2]);
            string direccion = datosEncontrados[3];
            long telefono = long.Parse(datosEncontrados[4]);
            string email = datosEncontrados[5];
            nroCuenta = long.Parse(datosEncontrados[7]);

            objPersona = new Personas(apellido, nombre, email, direccion, dni, telefono, Saldo, nroCuenta);
            objPersona.ModificarUsuario();
        }

        public void Interes()
        {
            Personas objPersona = new Personas(nroCuenta);
            string[] datosEncontrados = objPersona.BuscarUsuario();

            if (Saldo>0)
            {
                Saldo += (Saldo*InteresAnual/12);
            }
            else
            {
                Console.WriteLine("Ingresa un interes valido. O no tiene saldo suficiente");
            }


            string apellido = datosEncontrados[0];
            string nombre = datosEncontrados[1];
            long dni = long.Parse(datosEncontrados[2]);
            string direccion = datosEncontrados[3];
            long telefono = long.Parse(datosEncontrados[4]);
            string email = datosEncontrados[5];
            nroCuenta = long.Parse(datosEncontrados[7]);

            objPersona = new Personas(apellido, nombre, email, direccion, dni, telefono, Saldo, nroCuenta);
            objPersona.ModificarUsuario();
        }
        


    }
}
